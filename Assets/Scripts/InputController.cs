using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public event Action OnJump;

    public float Horizontal
    {
        get
        {
            return _horizontal;
        }
    }

    public static InputController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<InputController>();

            return _instance;
        }
    }

    private float _horizontal;

    private static InputController _instance;

    public void GoRight()
    {
        _horizontal = 1;
    }

    public void GoLeft()
    {
        _horizontal = -1;
    }

    public void Annulate()
    {
        _horizontal = 0;
    }

    public void Jump()
    {
        OnJump?.Invoke();
    }
}
