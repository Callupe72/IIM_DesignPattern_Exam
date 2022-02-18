using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    [Range(0, 100)][SerializeField] int _percentChangeToDropPotion = 25;
    [SerializeField] GameObject _potion;

    public void Touch(int power)
    {
        RandomDropPotion();
        Destroy(gameObject);
    }

    public void RandomDropPotion()
    {
        //Make the random on 100
        int randomResult = Random.Range(0, 100);
        if (randomResult < _percentChangeToDropPotion)
        {
            Instantiate(_potion, transform.position, Quaternion.identity);
        }
    }
}
