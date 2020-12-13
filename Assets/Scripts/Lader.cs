using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    private DadyController _player;

    private bool stop;

    public void OnTriggerEnter2D(Collider2D col)
    {
        _player = col.GetComponent<DadyController>();
        if (_player != null)
        {
            stop = false;
            UIManager.Instance.ActivateLaderBt(this);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        _player = col.GetComponent<DadyController>();
        if (_player != null)
        {
            UIManager.Instance.DeactivateLaderBt();
        }
    }

    public void MovePLayer()
    {
        
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        _player.enabled = false;
        var playerCol = _player.GetComponent<Collider2D>();

        playerCol.enabled = false;

        var coef = 1;
        if (_player.transform.position.y < transform.parent.position.y + 1f)
        {
            coef = 1;
            _player.transform.position = transform.TransformPoint(Vector3.zero) - new Vector3(0, 1, 0);
        }
           
        else
        {
            coef = -1;
            _player.transform.position = transform.TransformPoint(Vector3.zero) + new Vector3(0, transform.parent.position.y, 0);
        }

        if (coef == 1)
        {
            while (Vector2.Distance(new Vector2(0, _player.transform.position.y),
                       new Vector2(0, transform.parent.position.y + 1f)) > 0.1)
            {
                var rb = _player.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, _player.LaderSpeed * coef);
                yield return null;
            }
        }

        if (coef == -1)
        {
            while (Vector2.Distance(new Vector2(0, _player.transform.position.y),
                       new Vector2(0, transform.parent.position.y -3f)) > 0.1)
            {
                var rb = _player.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, _player.LaderSpeed * coef);
                yield return null;
            }
        }

        playerCol.enabled = true;
        _player.enabled = true;
    }
}
