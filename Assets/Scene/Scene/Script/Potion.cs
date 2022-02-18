using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IObject
{
    [SerializeField] int healthAmount = 3;


    public void OnTouchPlayer(Health player)
    {
        player.Heal(healthAmount);
        Destroy(transform.parent.gameObject);
    }
}
