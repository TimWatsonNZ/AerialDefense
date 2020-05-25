using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown {
    float CooldownTime;
    float _nextFireTime;

    public Cooldown(float time)
    {
        CooldownTime = time;
        _nextFireTime = Time.time;
    }

    public void Fire()
    {
        if (IsReady())
        {
            _nextFireTime = Time.time + CooldownTime;
        }
    }

    public bool IsReady()
    {
        return Time.time > _nextFireTime;
    }
}
