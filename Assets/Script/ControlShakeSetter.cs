using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShakeSetter : MonoBehaviour
{
    [SerializeField] ControlShake _controlShake;
    [SerializeField] ControlShakeReference _controlShakeRef;

    #region EDITOR

    private void Reset()
    {
        //Récupère le control shake sur lui-même(il le trouve dans ses components)
        _controlShake = GetComponent<ControlShake>();
    }

    #endregion

    private void Awake()
    {
        //On donne le control shake à la référence pour que le player (et tous les autres scripts qui veulent)
        //puissent y accéder quand ils le désirent
        IReferenceSetter<ControlShake> reference = _controlShakeRef;
        reference.SetInstance(_controlShake);
    }

}