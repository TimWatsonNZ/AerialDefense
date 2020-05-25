using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Enemy {

    public Animator animator;
    float deathAnimationLength = 0.3f;
    float timeToDestroy;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (alive && transform.position.y <= -Camera.main.orthographicSize + 1 + transform.localScale.y / 4)
        {
            animator.SetBool("hitsGround", true);
            timeToDestroy = Time.time + deathAnimationLength;
            alive = false;

            var collidedWith = Physics2D.OverlapCircleAll(transform.position, 1.5f);
            foreach (var entity in collidedWith)
            {
                if (entity.tag == "Player")
                {
                    IDamageable damageable = entity.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeHit(1);
                    }
                    break;
                }
            }

        }

        if (Time.time > timeToDestroy && !alive)
        {
            Destroy(gameObject);
        }
    }
}
