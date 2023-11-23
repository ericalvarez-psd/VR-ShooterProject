using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TargetManager : MonoBehaviour
{
    public GameObject targetPrefab;

    public float minSpawnTime, maxSpawnTime;

    BoxCollider spawnBox;

    float spawnTimer = 0, spawnTime;

    private void Start()
    {
        spawnBox = GetComponent<BoxCollider>();
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
        Vector3 startPos = new Vector3(Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x),
                                       Random.Range(spawnBox.bounds.min.y, spawnBox.bounds.max.y),
                                       Random.Range(spawnBox.bounds.min.z, spawnBox.bounds.max.z));

        Instantiate(targetPrefab, startPos, transform.rotation);
    }
}
