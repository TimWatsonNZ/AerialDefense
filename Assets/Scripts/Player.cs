using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable {

    Cooldown cd;
    public Transform turret;
    public Transform pivotPoint;

    public float startingHealth;
    public float currentHealth;

    public Image healthMeter;

    public Weapon machineGun;
    public Weapon cannon;

    Weapon weapon;

    public System.Action OnDeath;

	void Start () {
        currentHealth = startingHealth;
        weapon = Instantiate(machineGun, transform);
	}
	

	void Update ()
    {
        var mousePosition = Input.mousePosition;
        Vector3 pointAt = (mousePosition - Camera.main.WorldToScreenPoint(this.transform.position)).normalized;
        float pointingAngle = Mathf.Atan2(pointAt.y, pointAt.x) * Mathf.Rad2Deg; 

        turret.transform.Translate(pivotPoint.transform.localPosition);
        turret.transform.rotation = Quaternion.Euler(new Vector3(0, 0, pointingAngle));
        turret.transform.Translate(-pivotPoint.transform.localPosition);

        if (Input.GetMouseButton(0))
        {
            weapon.Fire(transform.position, turret.transform.rotation, pointAt);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Instantiate(machineGun, transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Instantiate(cannon, transform);
        }
    }

    public void TakeHit(float damage)
    {
        currentHealth -= damage;
        Vector3 scale = healthMeter.transform.localScale;
        scale.y = currentHealth / startingHealth;
        healthMeter.transform.localScale = scale;

        if (currentHealth <= 0) {
            OnDeath();
            currentHealth = 0;
        }
    }
}
