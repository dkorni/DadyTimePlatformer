using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeathPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<DadyController>();
        if (player != null)
        {
            UIManager.Instance.ActivateTeathBt();
            Destroy(gameObject);
        }
    }
}
