using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;

    bool isShieldActive;

    [SerializeField] BulletPool bulletPooling;

    public void SetShieldActive(bool shieldActive)
    {
        isShieldActive = shieldActive;
    }

    public void FireBullet(int power)
    {
        if (isShieldActive)
            return;

        bulletPooling.SpawnBullet(transform.position, Quaternion.identity).Init(_spawnPoint.TransformDirection(Vector3.right), power);

        #region ByInstance
        //var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
          //  .Init(_spawnPoint.TransformDirection(Vector3.right), power);
        #endregion  
    }

}
