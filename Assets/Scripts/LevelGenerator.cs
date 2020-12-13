using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public GameObject PlayerPrefab;
    public GameObject DeathPrefab;
    public GameObject[] weapons;

    public int MaxPlatforms = 7;

    public List<Platform> Platforms;

    private int _counter = 1;

    private const float MIN_POS_X = -6.25f;
    private const float MAX_POS_X = 6.25f;

    private const float MIN_POS_Y = -4.46f;
    private const float MAX_POS_Y = 2.22f;

    private Platform _lstPlatform;

    private Vector2 _yMinMaxMatrixCurrent;
    private Vector2 _yMinMaxMatrix = new Vector2(MIN_POS_Y+0, MIN_POS_Y + 1.5f);

    private Vector2[] yMinMax = new Vector2[]
    {
        new Vector2(MIN_POS_Y, MIN_POS_Y+3), 
        new Vector2(MIN_POS_Y+3, MIN_POS_Y+9), 
        new Vector2(MIN_POS_Y+9, MAX_POS_Y), 
    };

    // Start is called before the first frame update
    void Start()
    {
       
           RegenerateLevel();

    }

    public void Generate()
    {
        _yMinMaxMatrixCurrent = _yMinMaxMatrix;

        // spawn first platform
        var firstPlatformPosX = Random.Range(MIN_POS_X, MAX_POS_X);
        var firstPlatformPosY = Random.Range(_yMinMaxMatrixCurrent.x, _yMinMaxMatrixCurrent.y);

   

        var firstPlatformPos = new Vector2(firstPlatformPosX, firstPlatformPosY);
        var ptf = Instantiate(PlatformPrefab, firstPlatformPos, Quaternion.identity);

        _lstPlatform = ptf.GetComponent<Platform>();


        _yMinMaxMatrixCurrent = new Vector2(_lstPlatform.transform.position.y+1, _lstPlatform.transform.position.y + 3f);

        // для каждого под левала
        for (int i = 0; i < 7; i++)
        {
            var randomDirectionX = Random.Range(0, 2);

            if (randomDirectionX == 0)
            {
                // so first try to start right
                if (GenerateRight(i))
                {
              
                }
                else
                {
                    // try from left
                    GenerateRight(i);
                }
            }

            if (randomDirectionX == 1)
            {
                // try to start left
                if (GenerateLeft(i))
                {

                }
                else
                {
                    // try from right
                    GenerateRight(i);
                }
            }
        }

        SpawnPlayer();
        SpawnDeath();
        SpawnWeapon();
    }

    private void SpawnPlayer()
    {
        int index = Random.Range(0, Platforms.Count);

        // spawn player on random platform
        Instantiate(PlayerPrefab, (Vector2)Platforms[index].transform.position + new Vector2(0, 0.5f),
            Quaternion.identity);

        Platforms.RemoveAt(index);
    }

    private void SpawnDeath()
    {
        int index = Random.Range(0, Platforms.Count);

        // spawn player on random platform
        Instantiate(DeathPrefab, (Vector2)Platforms[index].transform.position + new Vector2(0, 1.5f),
            Quaternion.identity);

        Platforms.RemoveAt(index);
    }

    private void SpawnWeapon()
    {
        int index = Random.Range(0, Platforms.Count);
        int indexW = Random.Range(0, weapons.Length);

        // spawn player on random platform
        Instantiate(weapons[indexW], (Vector2)Platforms[index].transform.position + new Vector2(0, 0.5f),
            Quaternion.identity);

        Platforms.RemoveAt(index);
    }

    public void RegenerateLevel()
    {
        _counter = 0;
        while (_counter < 5)
        {
            CleanUp();
            Generate();
        }
    }

    private void CleanUp()
    {
        _counter = 0;
        Platforms.Clear();
        var objs = GameObject.FindGameObjectsWithTag("Cleanup");
        foreach (var obj in objs)
        {
            Destroy(obj);
        }
    }

    private bool GenerateRight(int subLevelNum)
    {
        int bound_mask = LayerMask.GetMask("Bound");
        var hit = Physics2D.Raycast(_lstPlatform.RightChecker.position, _lstPlatform.RightChecker.right, 100000, bound_mask);
        Debug.DrawRay(_lstPlatform.RightChecker.position, _lstPlatform.RightChecker.right, Color.red, 3);
        var dist = Vector2.Distance(_lstPlatform.transform.position, hit.point);

        Debug.Log($"Hitted into {hit.transform.name} distance = {dist}");

        if (dist > _lstPlatform.transform.position.x + 8f)
        {
            var nextXPos = Random.Range(_lstPlatform.transform.position.x + 5.2f,
                hit.point.x - 2.7f);

            var minMaxY = new Vector2[]
            {
                new Vector2(_lstPlatform.transform.position.y, _lstPlatform.transform.position.y - 3), // down 
                new Vector2(_lstPlatform.transform.position.y, _lstPlatform.transform.position.y + 3), // up 
            };

            var nextPosY = Random.Range(_yMinMaxMatrixCurrent.x, _yMinMaxMatrixCurrent.y);

            _yMinMaxMatrixCurrent += new Vector2(2, 2);

            var nextPos = new Vector2(nextXPos, nextPosY);

            var ptf = Instantiate(PlatformPrefab, nextPos, Quaternion.identity).GetComponent<Platform>();

            // check availability and activate laders if need
           // ptf.ActivateLaders();

            Platforms.Add(ptf);

            _lstPlatform = ptf;


            // check intersections
            _yMinMaxMatrixCurrent = new Vector2(_lstPlatform.transform.position.y + 1.6f, _lstPlatform.transform.position.y + 3f);

            _counter++;

            return true;
        }

        return false;
    }

    private bool GenerateLeft(int subLevelNum)
    {
        int bound_mask = LayerMask.GetMask("Bound"); 
        var hit = Physics2D.Raycast(_lstPlatform.LeftChecker.position, _lstPlatform.LeftChecker.right * -1, 100000, bound_mask);
        Debug.DrawRay(_lstPlatform.LeftChecker.position, _lstPlatform.LeftChecker.right*-1, Color.red, 3);
        var dist = Vector2.Distance(_lstPlatform.transform.position, hit.point);

        Debug.Log($"Hitted into {hit.transform.name} distance = {dist}");

        if (dist > Mathf.Abs(_lstPlatform.transform.position.x - 8f))
        {
            var nextXPos = Random.Range(_lstPlatform.transform.position.x - 5.2f,
                hit.point.x + 2.7f);

            var nextPosY = Random.Range(_yMinMaxMatrixCurrent.x, _yMinMaxMatrixCurrent.y);

            _yMinMaxMatrixCurrent += new Vector2(2, 2);

            var nextPos = new Vector2(nextXPos, nextPosY);

            var ptf = Instantiate(PlatformPrefab, nextPos, Quaternion.identity).GetComponent<Platform>();

            // check availability and activate laders if need
            //  ptf.ActivateLaders();

            Platforms.Add(ptf);

            _lstPlatform = ptf;

            _yMinMaxMatrixCurrent = new Vector2(_lstPlatform.transform.position.y + 1.6f, _lstPlatform.transform.position.y+ 3f);

            _counter++;

            return true;
        }

        return false;
    }
}
