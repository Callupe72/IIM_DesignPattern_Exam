using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth, ITouchable
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] UnityEvent _onDeath;
    
    //Cr�ation d'un boolean qui r�cup�re l'�tat du shield
    bool isShieldActive;
    public void SetShieldActive(bool shieldActive)
    {
        isShieldActive = shieldActive;
    }

    // Propri�t�s
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }

    // Methods
    void Awake() => Init();


    //Cr�ation d'un event qui sera appel� � chaque fois que la vie s'actualise (pour le slider entre autres)
    public event UnityAction OnChangeHealth;

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        if (isShieldActive)
            return;

        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");

        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        var delta = CurrentHealth - tmp;
        OnDamage?.Invoke(delta);

        if(CurrentHealth <= 0)
        {
            _onDeath?.Invoke();
        }

        //L'event est appel� pour le slider
        OnChangeHealth?.Invoke();
    }


    //Cr�ation d'une nouvelle fonction qui permet de heal le player
    public void Heal(int amount)
    {
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");
        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);

        //L'event est appel� pour le slider
        OnChangeHealth?.Invoke();
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while(enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }

    public void Touch(int power)
    {
        TakeDamage(power);
    }
}
