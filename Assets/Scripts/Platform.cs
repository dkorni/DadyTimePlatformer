using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform LeftChecker;
    public Transform RightChecker;
    public Transform LeftDownChecker;
    public Transform RightDownChecker;


    public GameObject LaderLeft;
    public GameObject LaderRight;

    public void ActivateLaders()
    {
        var hits = Physics2D.RaycastAll(LeftDownChecker.position, LeftDownChecker.up * -1, 4.5f);

        foreach (var hit in hits)
        {
            if(hit.transform.GetComponent<Platform>() && Vector2.Distance(new Vector2(0, hit.point.y), new Vector2(0, LeftDownChecker.position.y))>2.2)
                LaderLeft.SetActive(true);
        }

        hits = Physics2D.RaycastAll(RightDownChecker.position, RightDownChecker.up * -1, 4.5f);

        foreach (var hit in hits)
        {
            if (hit.transform.GetComponent<Platform>() && Vector2.Distance(new Vector2(0, hit.point.y), new Vector2(0, RightDownChecker.position.y)) > 2.2)
                LaderRight.SetActive(true);
        }
    }
}
