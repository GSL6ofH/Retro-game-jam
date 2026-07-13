using UnityEngine;
using System.Collections.Generic;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public int numberOfTrees = 50;
    public float spawnAreaSize = 50f;
    public List<Transform> noSpawnZones;
    void Start()
    {
        SpawnTrees();
    }
    void SpawnTrees()
    {
        int spawnedTrees = 0;
        int maxAttempts = 2000;
        int attempts = 0;
        while (spawnedTrees < numberOfTrees && attempts < maxAttempts)
        {
            attempts++;

            Vector3 randomPos = new Vector3(
                Random.Range(-spawnAreaSize, spawnAreaSize),
                0f,
                Random.Range(-spawnAreaSize, spawnAreaSize)
            );
            if (IsInsideNoSpawnZone(randomPos))
            {
                continue;
            }
            GameObject newTree = Instantiate(treePrefab, randomPos, Quaternion.identity);
            newTree.transform.parent = this.transform;
            newTree.transform.Rotate(0, Random.Range(0, 360f), 0);
            spawnedTrees++;
        }
    }
    bool IsInsideNoSpawnZone(Vector3 pos)
    {
        foreach (Transform zone in noSpawnZones)
        {
            if (zone != null)
            {
                Collider col = zone.GetComponent<Collider>();
                Vector3 checkPos = new Vector3(pos.x, zone.position.y, pos.z);
                if (col != null && col.bounds.Contains(checkPos))
                {
                    return true;
                }
            }
        }
        return false;
    }
}