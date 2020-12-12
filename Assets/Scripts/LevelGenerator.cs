using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public GameObject PlayerPrefab;

    public int MaxPlatforms = 7;

    private int _counter;

    private const float MIN_POS_X = -6.25f;
    private const float MAX_POS_X = 6.25f;

    private const float MIN_POS_Y = -4.46f;
    private const float MAX_POS_Y = 2.22f;

    private const float MAX_X_OFFSET = 5.2f;

    private Platform _lstPlatform;

    // Start is called before the first frame update
    void Start()
    {
       
        Generate();

    }

    public void Generate()
    {
        // spawn first platform
        var firstPlatformPosX = Random.Range(MIN_POS_X, MAX_POS_X);
        var firstPlatformPosY = Random.Range(MIN_POS_Y, MAX_POS_Y);

        var firstPlatformPos = new Vector2(firstPlatformPosX, firstPlatformPosY);
        var ptf = Instantiate(PlatformPrefab, firstPlatformPos, Quaternion.identity);

        // todo
        // spawn player on random platform
        Instantiate(PlayerPrefab, (Vector2) ptf.transform.position + new Vector2(0, 1.5f),
            Quaternion.identity);

        _lstPlatform = ptf.GetComponent<Platform>();

        for (int i = 0; i < 1; i++)
        {
            var randomDirectionX = Random.Range(0, 1);

            GenerateRight();

            //if (randomDirectionX == 0)
            //{
            //    GenerateRight();
            //}

            //if (randomDirectionX == 1)
            //{
            //    GenerateLeft();
            //}
        }
    }

    public void RegenerateLevel()
    {
        CleanUp();
        Generate();
    }

    private void CleanUp()
    {
        var objs = GameObject.FindGameObjectsWithTag("Cleanup");
        foreach (var obj in objs)
        {
            Destroy(obj);
        }
    }

    private void GenerateRight()
    {
        var hit = Physics2D.Raycast(_lstPlatform.RightChecker.position, _lstPlatform.RightChecker.right, 100000);
        Debug.DrawRay(_lstPlatform.RightChecker.position, _lstPlatform.RightChecker.right, Color.red, 3);
        var dist = Vector2.Distance(_lstPlatform.transform.position, hit.point);

        Debug.Log($"Hitted into {hit.transform.name} distance = {dist}");

        if (dist > _lstPlatform.transform.position.x + 10.8f)
        {
            var nextXPos = Random.Range(_lstPlatform.transform.position.x + 5.2f,
                hit.point.x - 2.7f);

            var nextPos = new Vector2(nextXPos, _lstPlatform.transform.position.y);

            var ptf = Instantiate(PlatformPrefab, nextPos, Quaternion.identity).GetComponent<Platform>();
            _lstPlatform = ptf;
        }

        //if (dist < MAX_POS_X + 5.2f && dist > _lstPlatform.transform.position.x + 5.4f)
        //{
        //    var maxSpawnDist = Mathf.Max(0,hit.point.x - 10.4f); 

        //    var nextXPos = Random.Range(_lstPlatform.transform.position.x + 2.7f,
        //        maxSpawnDist);

        //    var nextPos = new Vector2(nextXPos, _lstPlatform.transform.position.y);

        //    var ptf = Instantiate(PlatformPrefab, nextPos, Quaternion.identity).GetComponent<Platform>();
        //    _lstPlatform = ptf;
        //}
    }

    private void GenerateRight(Platform platform)
    {

    }
}
