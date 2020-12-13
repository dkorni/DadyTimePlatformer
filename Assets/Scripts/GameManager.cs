using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DadyController Player;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    private static GameManager _instance;

    public void AttackTeath()
    {
        Player?.AttackTeath();
        UIManager.Instance.DeactivateTeathBt();
    }
}