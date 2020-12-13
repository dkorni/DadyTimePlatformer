using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AudioManager>();

            return _instance;
        }
    }

    private static AudioManager _instance;

    [SerializeField] private GameObject _walk;

    [SerializeField] private AudioClip _jumpClip;

    [SerializeField] private AudioSource _audioSource;

    public void EnableWalking()
    {
        _walk.SetActive(true);
    }

    public void DisableWalking()
    {
        _walk.SetActive(false);
    }

    public void Jump()
    {
        _audioSource.PlayOneShot(_jumpClip);
    }
}
