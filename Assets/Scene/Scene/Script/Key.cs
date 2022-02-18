using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IObject
{
    [SerializeField] GameObject _gateToOpen;

    public void OnTouchPlayer(Health player)
    {
        _gateToOpen.SetActive(false);
        Destroy(transform.parent.gameObject);
    }
}
