using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitfire : Enemy
{
    float deathAnimationLength = 0.5f;
    float timeToDestroy;
    public Animator animator;

    // Use this for initialization
    void Start () {
        moveSpeed = 5;
        if (movement.x < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(deathAnimationLength);
        Destroy(gameObject);
    }

    public override void TakeHit(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && alive)
        {
            alive = false;
            animator.SetBool("isDead", true);
            StartCoroutine(WaitThenDestroy());
        }
    }
}
