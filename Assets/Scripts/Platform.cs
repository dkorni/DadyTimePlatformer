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

    public void CorrectPositions()
    {
        var hits = Physics2D.RaycastAll(LeftDownChecker.position, LeftDownChecker.up * -1, 4.5f);

        Debug.DrawRay(LeftDownChecker.position, LeftDownChecker.up * -1, Color.green, 5);

        foreach (var hit in hits)
        {
            var dist = Vector2.Distance(new Vector2(0, hit.point.y), new Vector2(0, LeftDownChecker.position.y));
            if (hit.transform.GetComponent<Platform>() && dist > 2.5)
            {
                // LaderLeft.SetActive(true);
            }
            else
            {
                // we need to move up platform
                var offset = 3f - dist;
                transform.position += new Vector3(0, offset,0);
            }
        }
        
        hits = Physics2D.RaycastAll(LeftDownChecker.position - new Vector3(2.5f, 0,0), LeftDownChecker.up * -1, 4.5f);

        Debug.DrawRay(LeftDownChecker.position - new Vector3(2.5f, 0, 0), LeftDownChecker.up * -1, Color.green, 5);

        foreach (var hit in hits)
        {
            var dist = Vector2.Distance(new Vector2(0, hit.point.y), new Vector2(0, LeftDownChecker.position.y));
            if (hit.transform.GetComponent<Platform>() && dist > 2.5)
            {
                //LaderLeft.SetActive(true);
            }
            else
            {
                // we need to move up platform
                var offset = 3f - dist;
                transform.position += new Vector3(0, offset, 0);
            }
        }

        hits = Physics2D.RaycastAll(RightDownChecker.position, RightDownChecker.up * -1, 4.5f);

        Debug.DrawRay(RightDownChecker.position, LeftDownChecker.up * -1, Color.green, 5);

        foreach (var hit in hits)
        {
            var dist = Vector2.Distance(new Vector2(0, hit.point.y), new Vector2(0, RightDownChecker.position.y));
            if (hit.transform.GetComponent<Platform>() && dist > 2.5)
            {
                // LaderRight.SetActive(true);
            }
            else
            {
                // we need to move up platform
                var offset = 3f - dist;
                transform.position += new Vector3(0, offset, 0);
            }
        }

        hits = Physics2D.RaycastAll(RightDownChecker.position + new Vector3(2.5f, 0, 0), RightDownChecker.up * -1, 4.5f);

        Debug.DrawRay(RightDownChecker.position + new Vector3(2.5f, 0, 0), LeftDownChecker.up * -1, Color.green, 5);

        foreach (var hit in hits)
        {
            var dist = Vector2.Distance(new Vector2(0, hit.point.y), new Vector2(0, RightDownChecker.position.y));
            if (hit.transform.GetComponent<Platform>() && dist > 2.5)
            {
             //   LaderRight.SetActive(true);
            }
            else
            {
                // we need to move up platform
                var offset = 3 - dist;
                transform.position += new Vector3(0, offset, 0);
            }
        }
    }
}
