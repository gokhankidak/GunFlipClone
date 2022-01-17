using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] GunController _gun;
    // Update is called once per frame

    bool _isActive = true;

    void OnFire()
    {
        if (_isActive) _gun.Fire();
        else RestartGame();
    }

    void RestartGame()
    {
        throw new NotImplementedException();
    }
}
