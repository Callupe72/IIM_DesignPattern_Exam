using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;

public class BulletPool : MonoBehaviour
{
    [SerializeField] int bulletStock = 20;
    [SerializeField] Bullet bulletPref;

    //Bullet disponibles
    List<Bullet> bulletsAvailable = new List<Bullet>();

    //Bullet en cours d'utilisation
    List<Bullet> bulletsInAction = new List<Bullet>();

    [Button("Spawn bullets")]
    void InitStartStock()
    {
        //Initialisation du stock lors en editor, pour éviter que cette action se fasse en runtime
        //  ----> Détruit les bullets existantes
        var tempList = transform.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {
            DestroyImmediate(child.gameObject);
        }
        bulletsAvailable.Clear();

        //  ----> Spawn les nouvelles
        for (int i = 0; i < bulletStock; i++)
        {
            Bullet bullet = Instantiate(bulletPref);
            bullet.transform.parent = transform;
            bullet.SetPool(this);
            bulletsAvailable.Add(bullet);
            bullet.gameObject.SetActive(false);
        }

        Debug.Log($"I succesfully spawned {bulletStock} bullets spawned");
    }

    //Les entity fire qui ont besoin de faire spawn une bullet vont utiliser cette fonction
    public Bullet SpawnBullet(Vector3 startingPos, Quaternion startingRot)
    {
        //Si la pile contient des bullets, prend la 1ere de la liste
        //puis met la dans la liste des bullets en cours d'utilisation
        if(bulletsAvailable.Count > 0)
        {
            bulletsInAction.Add(bulletsAvailable[0]);
            bulletsAvailable.Remove(bulletsAvailable[0]);
            bulletsInAction[bulletsInAction.Count - 1].gameObject.SetActive(true);
            bulletsInAction[bulletsInAction.Count - 1].transform.position = startingPos;
            bulletsInAction[bulletsInAction.Count - 1].transform.rotation = startingRot;
            return bulletsInAction[bulletsInAction.Count-1];
        }
        //Si la pile est vide, créé une nouvelle bullet
        else
        {
            Bullet bullet = Instantiate(bulletPref);
            bullet.gameObject.SetActive(true);
            bullet.SetPool(this);
            bulletsInAction.Add(bullet);
            bullet.transform.position = startingPos;
            bullet.transform.rotation = startingRot;
            return bullet;
        }
    }

    //Une fois que les Bullets sont sensés se détruire, elles se désactivent puis s'ajoutent
    //à la liste des bullets disponibles
    public void EndWithThisBullet(Bullet currentBullet)
    {
        currentBullet.gameObject.SetActive(false);
        foreach (Bullet bull in bulletsInAction)
        {
            if(bull == currentBullet)
            {
                bull.StopAllCoroutines();
                bulletsAvailable.Add(bull);
                bulletsInAction.Remove(bull);
                return;
            }
        }
    }
}
