using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetObjectVolume : MonoBehaviour
{
    Health healthPlayer;
    void Start()
    {
        if(healthPlayer == null)
            healthPlayer = GetComponentInParent<Health>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IObject>(out IObject objTouched))
        {
            objTouched?.OnTouchPlayer(healthPlayer);
        }
    }
}
