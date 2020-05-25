using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    public Enemy EnemyPrefab;
    public float SpawnTime;
    public Vector2 Position;
    public bool spawned = false;
    public Vector3 MoveVector;
}

public class SpawnManager : MonoBehaviour {

    public Transport transportPrefab;
    public Spitfire spitfirePrefab;
    public Bomber bomberPrefab;
    public List<EnemySpawner> spawners;
    public int EnemyCount = 0;
    float levelStartTime = 0;

    public SpawnManager()
    {
        spawners = new List<EnemySpawner>();
    }

    public void InitStartTime()
    {
        levelStartTime = Time.time;
    }

    public bool FinishedSpawning()
    {
        return spawners.Count == 0;
    }

    void OnChildDeath()
    {
        EnemyCount--;
    }

    public void Spawn(Level parent)
    {
        foreach (EnemySpawner currentSpawner in spawners)
        {
            if (currentSpawner.spawned == false && Time.time > currentSpawner.SpawnTime + levelStartTime)
            {
                var child = GameObject.Instantiate(currentSpawner.EnemyPrefab, currentSpawner.Position, Quaternion.identity);
                parent.AddChild(child);
                child.parent = parent;
                EnemyCount++;
                child.OnDeath += OnChildDeath;
                currentSpawner.spawned = true;
                child.movement = currentSpawner.MoveVector;
            }
        }
        spawners.RemoveAll(spawner => spawner.spawned);
    }

    public void AddTransport(float spawnTime, Vector3 position, Vector3 moveVector)
    {
        spawners.Add(new EnemySpawner
        {
            EnemyPrefab = transportPrefab,
            SpawnTime = spawnTime,
            Position = position,
            MoveVector = moveVector,
        });
    }

    public void AddSpitfire(float spawnTime, Vector3 position, Vector3 moveVector)
    {
        spawners.Add(new EnemySpawner
        {
            EnemyPrefab = spitfirePrefab,
            SpawnTime = spawnTime,
            Position = position,
            MoveVector = moveVector,
        });
    }

    public void AddBomber(float spawnTime, Vector3 position, Vector3 moveVector)
    {
        spawners.Add(new EnemySpawner
        {
            EnemyPrefab = bomberPrefab,
            SpawnTime = spawnTime,
            Position = position,
            MoveVector = moveVector,
        });
    }
}
