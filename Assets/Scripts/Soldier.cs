using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Enemy {

    public AnimationClip parachute;
    public Animator animator;

    Player player;

    bool isDying = false;
    float deathAnimationLength = 0.3f;
    float timeToDestroy;

    Vector3 moveVector;

	void Start () {
        moveVector = Vector3.down;
        player = FindObjectOfType<Player>();
        currentHealth = startingHealth;
	}

    void Update()
    {
        if (transform.position.y <= -Camera.main.orthographicSize + 1 + transform.localScale.y / 4)
        {
            animator.SetBool("hasLanded", true);
            var position = transform.position;
            position.y = -Camera.main.orthographicSize + 1f + transform.localScale.y / 4;
            transform.position = position;

            if (player != null)
            {
                moveVector = (player.transform.position - transform.position).normalized;
            }
            moveVector.y = 0;
            moveSpeed = 1;

            if (moveVector.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
        transform.position += moveSpeed * moveVector * Time.fixedDeltaTime;

        if (currentHealth <= 0 && Time.time > timeToDestroy)
        {
            Destroy(gameObject);
        }

        if (player != null)
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1 &&
                 Mathf.Abs(transform.position.y - player.transform.position.y) < 1)
            {
                player.TakeHit(1);
                Destroy(gameObject);
            }
        }
    }

    public override void TakeHit(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDying)
        {
            isDying = true;
            animator.SetBool("isDead", true);
            timeToDestroy = Time.time + deathAnimationLength;
        }
    }
}
