using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [Header("Damage Attributes")]
    [SerializeField] float damage = 100.0f;
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] float projectileCooldown = 1f;

    public float getDmg()
    {
        return damage;
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }

    public float getProjectileSpeed()
    {
        return projectileSpeed;
    }

    public float getProjectileCD()
    {
        return projectileCooldown;
    }
}
