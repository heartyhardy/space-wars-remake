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
    float baseFireCD = 0f;
    float fireCooldown;

    [Header("Weapons")]
    [SerializeField] GameObject basicWeapon;

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

        PlayOnFireFeedback();

        fireCooldown = UnityEngine.Random.Range(
            (baseFireCD - fireCDRandomness) > 0 ? (baseFireCD - fireCDRandomness) : fireCDRandomness,
            baseFireCD + fireCDRandomness
            );

    }

    private void PlayOnFireFeedback()
    {
        gameObject.GetComponent<AuditoryFeedback>().playOnFireFeedback();
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
        playOnHitFeedback();

        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void playOnHitFeedback()
    {
        gameObject.GetComponent<AuditoryFeedback>().playOnHitFeedback();
    }

    private void Die()
    {
        Destroy(gameObject);
        playDeathAnimation();
    }

    private void playDeathAnimation()
    {
        GameObject deathVfx = gameObject.GetComponent<DeathAnimation>().getVFX();
        AudioClip deathSfx = gameObject.GetComponent<DeathAnimation>().getSFX();
        float duration = gameObject.GetComponent<DeathAnimation>().getDuration();
        float volume = gameObject.GetComponent<DeathAnimation>().getSfxVolume();

        GameObject explosion = Instantiate(
                deathVfx,
                transform.position,
                Quaternion.identity
            );
        AudioSource.PlayClipAtPoint(
                deathSfx,
                Camera.main.transform.position,
                volume
            );
        Destroy(explosion, duration);

    }
}
