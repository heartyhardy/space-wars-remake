using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] float damage = 100.0f;
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] bool isEnemy = false;

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

    public bool IsEnemy()
    {
        return this.isEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //OnHit();
    }
}
