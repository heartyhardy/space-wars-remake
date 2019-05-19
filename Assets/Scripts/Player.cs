using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] float healthPoints = 500f;

    [Header("Movement")]
    [SerializeField] private float horizontalMoveSpeed = 7f;
    [SerializeField] private float verticalMoveSpeed = 10f;

    private float viewXMin;
    private float viewXMax;
    private float viewYMin;
    private float viewYMax;
    const float VIEW_PADDING = 1f;

    [Header("Weapons")]
    [SerializeField] private GameObject playerWeapon;

    Coroutine fireCoroutine;

    // Use this for initialization
    void Start()
    {
        SetMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void setHP(float hp)
    {
        this.healthPoints = hp;
    }

    public float getHP()
    {
        return this.healthPoints;
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(RapidFireMode());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator RapidFireMode()
    {
        while (true)
        {
            GameObject projectile = Instantiate(
                   playerWeapon,
                   transform.position,
                   Quaternion.identity
                );

            float projectileSpeed = projectile.GetComponent<DamageDealer>().getProjectileSpeed();
            float projectileCD = projectile.GetComponent<DamageDealer>().getProjectileCD();

            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    0,
                    projectileSpeed
                );

            yield return new WaitForSeconds(projectileCD);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * verticalMoveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, viewXMin, viewXMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, viewYMin, viewYMax);

        transform.position = new Vector2(
               newXPos,
               newYPos
            );
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

    private void SetMoveBoundaries()
    {
        Camera gameCam = Camera.main;

        viewXMin = gameCam.ViewportToWorldPoint(
                new Vector3(
                        0,
                        0,
                        0
                    )).x + VIEW_PADDING;

        viewXMax = gameCam.ViewportToWorldPoint(
                new Vector3(
                    1,
                    0,
                    0
                )).x - VIEW_PADDING;

        viewYMin = gameCam.ViewportToWorldPoint(
        new Vector3(
                0,
                0,
                0
            )).y + VIEW_PADDING;

        viewYMax = gameCam.ViewportToWorldPoint(
        new Vector3(
                0,
                1,
                0
            )).y - VIEW_PADDING;
    }
}
