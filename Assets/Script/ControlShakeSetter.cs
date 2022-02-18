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
        //R�cup�re le control shake sur lui-m�me(il le trouve dans ses components)
        _controlShake = GetComponent<ControlShake>();
    }

    #endregion

    private void Awake()
    {
        //On donne le control shake � la r�f�rence pour que le player (et tous les autres scripts qui veulent)
        //puissent y acc�der quand ils le d�sirent
        IReferenceSetter<ControlShake> reference = _controlShakeRef;
        reference.SetInstance(_controlShake);
    }

}