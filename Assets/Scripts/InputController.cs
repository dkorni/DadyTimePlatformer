using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public InputController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<InputController>();

            return _instance;
        }
    }

    private InputController _instance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
