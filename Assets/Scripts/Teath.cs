using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teath : MonoBehaviour
{
    private Death target;
    public float Speed = 5.0f;

    public void Start()
    {
        target = FindObjectOfType<Death>();
    }

    public void Update()
    {
        var direaction = target.transform.position - transform.position;
       transform.Translate(direaction * Speed);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        var death = collision.transform.GetComponent<Death>();
        if (death != null)
        {
            Destroy(death.gameObject);
            Destroy(gameObject);
        }
    }
}
