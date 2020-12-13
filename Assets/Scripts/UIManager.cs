using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _laderBt;
    [SerializeField] private Text _healthText;
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private Image _teathBt;

    [SerializeField] private Sprite _teathActive;
    [SerializeField] private Sprite _teathDisabled;

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

    public void UpdateHealthText(float health)
    {
        _healthText.text = health.ToString();
    }

    public void ShowDeathPanel()
    {
        _deathPanel.SetActive(true);
        _deathPanel.GetComponent<Animator>().Play("DeathMenu");
    }

    public void ActivateTeathBt()
    {
        _teathBt.sprite = _teathActive;
        _teathBt.GetComponent<Button>().enabled = true;
    }

    public void DeactivateTeathBt()
    {
        _teathBt.sprite = _teathDisabled;
        _teathBt.GetComponent<Button>().enabled = false;
    }

    public void HideDeathPanel()
    {
        _deathPanel.SetActive(false);
    }
}
