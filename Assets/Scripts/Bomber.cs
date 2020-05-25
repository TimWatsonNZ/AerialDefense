using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy {

    public Bomb bombPrefab;
    public float spawnTimer = 1;
    float nextSpawn;
    float timeToDestroy;

    // Use this for initialization
    void Start()
    {
        nextSpawn = Time.time + spawnTimer;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            var bomb = Instantiate(bombPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            nextSpawn = Time.time + spawnTimer;
            parent.AddChild(bomb);
            bomb.movement = new Vector3(0, -2);
        }

        if (movement.x > 0 && transform.position.x - transform.localScale.x / 2 > Camera.main.orthographicSize * Camera.main.aspect)
        {
            Destroy(gameObject);
            return;
        }

        if (currentHealth <= 0 && Time.time > timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
