using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Vector3 movement;
    protected float moveSpeed = 3;
    public float startingHealth = 2;
    protected float currentHealth;
    protected bool alive = true;
    public string behaviour;
    public Level parent;

    public System.Action OnDeath;

    public float CollisionDamage
    {
        get
        {
            return 1;
        }
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }

    public void Kill()
    {
        alive = false;

        if (OnDeath != null)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }

    public virtual void TakeHit(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    protected void FixedUpdate()
    {
        if (alive)
        {
            transform.position += movement * moveSpeed * Time.fixedDeltaTime;
        }
        
    }
}
