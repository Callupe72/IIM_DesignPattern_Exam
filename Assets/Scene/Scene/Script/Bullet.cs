using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;
    [SerializeField] BulletPool _pool;
    [SerializeField] float _timeBeforeDestroy = 3f;
    [SerializeField] UnityEvent EventOnHit;

    [SerializeField] GameObject particles;
    [SerializeField] AudioSource sfx;

    void Start()
    {
        EventOnHit.AddListener(PlaySFXOnHit);
        EventOnHit.AddListener(PlayParticlesOnHit);
    }

    void OnDestroy()
    {

    }

    public void SetPool(BulletPool newPool)
    {
        _pool = newPool;
    }

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        StartCoroutine(DestroyAfterTime());
        return this;
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_timeBeforeDestroy);
        EndOfThisObject();
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }

    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        //Regarde si la collision contient l'interface ITouchable
        if (collision.TryGetComponent<ITouchable>(out ITouchable touchable))
        {
            touchable.Touch(Power);
            EventOnHit?.Invoke();
            EndOfThisObject();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;


        //Regarde si la collision contient l'interface ITouchable
        if (collision.collider.TryGetComponent<ITouchable>(out ITouchable touchable))
        {
            touchable.Touch(Power);
            EventOnHit?.Invoke();
            EndOfThisObject();
        }
    }

    void EndOfThisObject()
    {
        //Lorsque la bullet finit son action
        _pool.EndWithThisBullet(this);
    }

    void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }

    public void PlayParticlesOnHit()
    {
        GameObject partic = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(partic, .5f);
    }
    public void PlaySFXOnHit()
    {
        GameObject sfxSpawned = Instantiate(sfx.gameObject, transform.position, Quaternion.identity);
        Destroy(sfxSpawned, .5f);
    }
}
