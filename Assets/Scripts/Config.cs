using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Config>();

            return _instance;
        }
    }

    private static Config _instance;


    public bool IsKeyboard { get; private set; }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            IsKeyboard = true;
        }
    }
}
