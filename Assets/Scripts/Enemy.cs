using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float heathPoints = 200f;
    [SerializeField] float fireCooldown;
    [SerializeField] float maxFireCD = 2f;
    [SerializeField] float minFireCD = .5f;
    [SerializeField] GameObject basicWeapon;

    // Use this for initialization
    void Start()
    {
        fireCooldown = UnityEngine.Random.Range(minFireCD, maxFireCD);
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

        fireCooldown = UnityEngine.Random.Range(minFireCD, maxFireCD);

    }

    private void setHP(float hp)
    {
        this.heathPoints = hp;
    }

    public float getHP()
    {
        return heathPoints;
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        DamageDealer dmg = collisionObject.GetComponent<DamageDealer>();
        ProcessHit(dmg, dmg.IsEnemy());
    }

    private void ProcessHit(DamageDealer dmg, bool isEnemy)
    {
        if (!isEnemy)
        {

        setHP(
            (heathPoints - dmg.getDmg() > 0) ? heathPoints - dmg.getDmg() : 0
        );

            if (heathPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
