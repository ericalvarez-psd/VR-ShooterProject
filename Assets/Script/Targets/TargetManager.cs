using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static float startZPos = 48, endZPos = 5;

    public static float hideYPos = 5.6f, showYPos = 2.5f;

    public static float minXPos = -0.2f, maxXPos = 8.3f;

    public GameObject targetPrefab;

    public float minSpawnTime = 0.5f, maxSpawnTime = 3;

    float spawnTimer = 0, spawnTime;

    private void Start()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        CheckSpawn();
    }

    void CheckSpawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            CreateTarget();
            spawnTimer = 0;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    void CreateTarget()
    {
        Vector3 startPos = new Vector3(Random.Range(minXPos, maxXPos), hideYPos, startZPos);
        Instantiate(targetPrefab, startPos, Quaternion.Euler(0, 180, 0));
    }
}
