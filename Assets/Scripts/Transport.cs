using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : Enemy {

    public Enemy parachutePrefab;

    public float spawnTimer = 1;
    public Animator animator;
    float nextSpawn;
    float deathAnimationLength = 0.5f;
    float timeToDestroy;

	// Use this for initialization
	void Start () {
        nextSpawn = Time.time + spawnTimer;
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextSpawn)
        {
            var parachuter = Instantiate(parachutePrefab, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnTimer;
            parent.AddChild(parachuter);
        }

        if (movement.x > 0 && transform.position.x - transform.localScale.x/2 > Camera.main.orthographicSize * Camera.main.aspect)
        {
            Destroy(gameObject);
            return;
        }

        if (currentHealth <= 0 && Time.time > timeToDestroy)
        {
            Destroy(gameObject);
        }
	}

    public override void TakeHit(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            timeToDestroy = Time.time + deathAnimationLength;
        }
    }
}
