using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _laderBt;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();

            return _instance;
        }
    }

    private static UIManager _instance;

    public void ActivateLaderBt(Lader lader)
    {
        _laderBt.gameObject.SetActive(true);
        _laderBt.onClick.AddListener(()=>lader.MovePLayer());
    }

    public void DeactivateLaderBt()
    {
        _laderBt.gameObject.SetActive(false);
        _laderBt.onClick.RemoveAllListeners();
    }
}
