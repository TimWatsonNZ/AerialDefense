using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShell : Bullet {
    public Animator animator;
    public float animationLength = 0.2f;
    bool isPlayingExplosionAnimation = false;

    IEnumerator WaitThenDestroy()
    {
        isPlayingExplosionAnimation = true;
        yield return new WaitForSeconds(animationLength);
        Destroy(gameObject);
    }

    protected override void FixedUpdate()
    {
        if (!isPlayingExplosionAnimation)
        {
            base.FixedUpdate();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { 
            if (AreaOfEffect > 1)
            {
                animator.SetBool("onHit", true);
                var collidedWith = Physics2D.OverlapCircleAll(transform.position, AreaOfEffect);
                foreach (var entity in collidedWith)
                {
                    if (entity.tag == "Enemy")
                    {
                        IDamageable damageable = entity.GetComponent<IDamageable>();
                        if (damageable != null)
                        {
                            damageable.TakeHit(damage);
                            StartCoroutine(WaitThenDestroy());
                        }
                    }
                }
            }
            else
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeHit(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
