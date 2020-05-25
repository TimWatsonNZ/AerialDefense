using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {
    int NumberOfShots = 5;
    float angleCone = 30;

    public override void Fire(Vector3 position, Quaternion rotation, Vector3 moveVector)
    {
        if (cooldown.IsReady())
        {
            Random.Range(-angleCone, angleCone);
            for (int i = 0;i < NumberOfShots;i++)
            {
                var moveAngle = Vector3.Angle(position, moveVector) -90 + Random.Range(-angleCone, angleCone);
                
                var bullet = Instantiate(bulletPrefab, position, rotation);
                bullet.moveVector = Quaternion.AngleAxis(moveAngle, Vector3.forward) * Vector3.right;
                bullet.moveSpeed = bulletSpeed;
            }
            cooldown.Fire();
            AudioManager.PlayFireSound();
        }
    }
}
