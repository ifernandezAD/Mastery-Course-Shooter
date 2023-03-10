using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnable[] prefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float respawnRate = 10;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private int totalNumberToSpawn;
    [SerializeField] private int numberToSpawnEachTime = 1;

    private float spawnTimer;
    private int totalNumberSpawned;

    private void OnEnable()
    {
        spawnTimer = respawnRate - initialSpawnDelay;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private bool ShouldSpawn()
    {
        if (totalNumberToSpawn > 0 && totalNumberSpawned >= totalNumberToSpawn)
        {
            return false;
        }

        return spawnTimer >= respawnRate;
    }

    private void Spawn()
    {
        spawnTimer = 0;

        var availableSpawnPoints = spawnPoints.ToList();

        for (int i = 0; i < numberToSpawnEachTime; i++)
        {
            if (totalNumberToSpawn > 0 && totalNumberSpawned >= totalNumberToSpawn)
            {
                break;
            }

            Spawnable prefab = ChooseRandomPrefab();
            if (prefab != null)
            {
                Transform spawnPoint = ChooseRandomSpawnPoint(availableSpawnPoints);

                if (availableSpawnPoints.Contains(spawnPoint))
                {
                    availableSpawnPoints.Remove(spawnPoint);
                }

                //var enemy = Instantiate(prefab,spawnPoint.position, spawnPoint.rotation);

                var enemy = prefab.Get<Spawnable>(spawnPoint.position, spawnPoint.rotation);

                totalNumberSpawned++;

            }
        }
    }

    private Transform ChooseRandomSpawnPoint(List<Transform> availableSpawnPoints)
    {
        if (availableSpawnPoints.Count == 0)
        {
            return transform;
        }

        if (availableSpawnPoints.Count == 1)
        {
            return availableSpawnPoints[0];
        }

        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);

        return availableSpawnPoints[index];
    }

    private Spawnable ChooseRandomPrefab()
    {
        if (prefabs.Length == 0)
        {
            return null;
        }

        if (prefabs.Length == 1)
        {
            return prefabs[0];
        }

        int index = UnityEngine.Random.Range(0, prefabs.Length);

        return prefabs[index];
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, Vector3.one);

        foreach (var spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint.position, 0.5f);
        }

    }
#endif


}


