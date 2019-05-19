using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] float healthPoints = 200f;    

    [Header("Attack Attributes")]
    [SerializeField] float fireCDRandomness = 1f;

    [Header("Weapons")]
    [SerializeField] GameObject basicWeapon;

    float baseFireCD = 0f;
    float fireCooldown;

    // Use this for initialization
    void Start()
    {
        baseFireCD = basicWeapon.GetComponent<DamageDealer>().getProjectileCD();
        fireCooldown = UnityEngine.Random.Range(
            (baseFireCD - fireCDRandomness) > 0 ? (baseFireCD - fireCDRandomness) : fireCDRandomness,
            baseFireCD + fireCDRandomness
            );
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0)
        {
            FireBasicWeapon();
        }
    }

    private void FireBasicWeapon()
    {
        GameObject projectile = Instantiate(
                basicWeapon,
                transform.position,
                Quaternion.identity
            );

        float projectileSpeed = projectile.GetComponent<DamageDealer>().getProjectileSpeed();

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(
                0,
                -projectileSpeed
            );
        
        fireCooldown = UnityEngine.Random.Range(
            (baseFireCD - fireCDRandomness) > 0 ? (baseFireCD - fireCDRandomness) : fireCDRandomness,
            baseFireCD + fireCDRandomness
            );

    }

    private void setHP(float hp)
    {
        this.healthPoints = hp;
    }

    public float getHP()
    {
        return healthPoints;
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        DamageDealer dmg = collisionObject.GetComponent<DamageDealer>();
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        setHP(
            (healthPoints - dmg.getDmg() > 0) ? healthPoints - dmg.getDmg() : 0
        );

        dmg.OnHit();

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
