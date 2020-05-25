using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    protected Cooldown cooldown;
    public Bullet bulletPrefab;
    public float firingRate;
    public float bulletSpeed = 1;
    public float damage = 1;
    
	void Start () {
        cooldown = new Cooldown(firingRate);
    }

    public virtual void Fire(Vector3 position, Quaternion rotation, Vector3 moveVector)
    {
        if (cooldown.IsReady())
        {
            cooldown.Fire();
            AudioManager.PlayFireSound();
            var bullet = Instantiate(bulletPrefab, position, rotation);
            bullet.moveVector = moveVector;
            bullet.moveSpeed = bulletSpeed;
            bullet.damage = damage;
        }
    }
}
