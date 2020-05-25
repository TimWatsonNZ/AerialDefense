using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;
    public Vector3 moveVector;
    public float AreaOfEffect = 1;
    public float damage = 1;

	protected virtual void FixedUpdate()
    {
        transform.position += moveVector * moveSpeed * Time.fixedDeltaTime;
    }

    void Update()
    {
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float screenHeight = Camera.main.orthographicSize;

        if (transform.position.x < -screenWidth - transform.localScale.x ||
            transform.position.x > screenWidth + transform.localScale.x ||
            transform.position.y > screenHeight + transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && other.tag != "Player")
        {
            damageable.TakeHit(damage);
            Destroy(gameObject);
        }
    }
}
