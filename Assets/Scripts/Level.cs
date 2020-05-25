using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LevelState
{
    None,
    Starting,
    Running,
    Ending,
}


public class Level : MonoBehaviour
{
    public string LevelName;
    public LevelStart levelStartPrefab;
    public LevelEnd levelEndPrefab;
    public System.Action OnLevelEnd;

    public float levelDuration = 100;

    LevelStart levelStartInstance;
    LevelEnd levelEndInstance;
    protected float nextSpawn;

    public SpawnManager spawnManager;

    LevelState state = LevelState.None;
    List<Enemy> children;

    void Start()
    {
        children = new List<Enemy>();
        state = LevelState.Starting;
        levelStartInstance = Instantiate(levelStartPrefab, transform);
        levelStartInstance.OnAnimationEnded += OnLevelStartEnd;
        levelStartInstance.level = this;
    }

    protected virtual void FillSpawners()
    {

    }

    public void AddChild(Enemy child)
    {
        children.Add(child);
    }

    void OnLevelStartEnd()
    {
        Destroy(levelStartInstance);
        FillSpawners();
        spawnManager.InitStartTime();
        this.state = LevelState.Running;
    }

    public void CleanUp()
    {
        print("Cleanup");
        print(children.Count);
        children.ForEach(child =>
        {
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        });
    }

    void EndLevel()
    {
        CleanUp();
        state = LevelState.Ending;
        levelEndInstance = Instantiate(levelEndPrefab, transform);
        levelEndInstance.OnAnimationEnded += OnLevelEndEnd;
        levelEndInstance.level = this;
    }

    void OnLevelEndEnd()
    {
        Destroy(levelEndInstance);
        OnLevelEnd();
    }

    // Update is called once per frame
    public void Update()
    {
        if (state == LevelState.Running)
        {
            float yMovePerSecond = Camera.main.orthographicSize / levelDuration;
            //background.position = new Vector3(background.position.x, background.position.y - (yMovePerSecond * Time.deltaTime), background.position.z);
            spawnManager.Spawn(this);
            if (spawnManager.FinishedSpawning() && spawnManager.EnemyCount == 0)
            {
                EndLevel();
            }
        }
    }
}
