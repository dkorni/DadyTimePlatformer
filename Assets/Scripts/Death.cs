using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float Speed;

    public float Damage = 33.4f;

    // Start is called before the first frame update

    private DadyController _dadyController;

    private Coroutine _attackCoroutine;

    [SerializeField] private float delay = .3f;

    void Start()
    {
        _dadyController = FindObjectOfType<DadyController>();
    }

    // Update is called once per frame
    void Update()
    {

        var direction = _dadyController.transform.position - transform.position;

        transform.Translate(direction*Speed*Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<DadyController>();
        if (player != null)
           _attackCoroutine = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (_dadyController != null)
        {
            _dadyController.SetDamage(Damage);
            yield return new WaitForSeconds(delay);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        var player = col.GetComponent<DadyController>();
        if (player != null)
            if (_attackCoroutine != null)
                StopCoroutine(_attackCoroutine);
    }
}
