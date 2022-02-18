using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Reference<ControlShake> _shakeRef;

    public Health Health => _health;

    void Awake()
    {
        _health.OnDamage += Shake;
    }

    void OnDestroy()
    {
        _health.OnDamage -= Shake;
    }

    //Utilisation d'une méthode intermediaire afin de ne pas rajouter un paramètre int
    //sur le ControlShake.LaunchScreenShake
    void Shake(int arg0)
    {
        _shakeRef.Instance.LaunchScreenShake();
    }

}


