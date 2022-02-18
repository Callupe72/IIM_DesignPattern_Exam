using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;

    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;

    Coroutine MovementTracking { get; set; }

    //Ajout du nouveau support
    [SerializeField] InputActionReference _shieldButton;
    [SerializeField] Health _health;

    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);

    private void Start()
    {
        // binding
        _fireButton.action.started += FireInput;

        _moveJoystick.action.started += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;

        //Ajout de l'action à la liste
        //----> Started récupère l'input lors de sa pression
        _shieldButton.action.started += HasShield;
        //----> Canceled récupère l'input lorsque la touche est relevée
        _shieldButton.action.canceled += HasShield;
    }

    private void OnDestroy()
    {
        _fireButton.action.started -= FireInput;

        _moveJoystick.action.started -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;

        //Suppression de l'action de la liste
        _shieldButton.action.started -= HasShield;
        _shieldButton.action.canceled -= HasShield;
    }


    //Cette fonction est appelée lorsque : 
        //  -shieldButton est pressé
        //  -shield button est relaché
        //  Ensuite Unity regarde si la touche est pressée ou non. Cela permet de ne pas avoir une fonction
        //  "OnShieldPressed" et une autre "OnShieldReleased"
    private void HasShield(InputAction.CallbackContext obj)
    {
        _health.SetShieldActive(obj.ReadValueAsButton());
        _fire.SetShieldActive(obj.ReadValueAsButton());
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        float fire = obj.ReadValue<float>();
        if(fire==1)
        {
            _fire.FireBullet(2);
        }
    }

}
