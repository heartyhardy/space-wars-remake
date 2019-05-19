using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float horizontalMoveSpeed = 7f;
    [SerializeField] private float verticalMoveSpeed = 10f;

    private float viewXMin;
    private float viewXMax;
    private float viewYMin;
    private float viewYMax;
    const float VIEW_PADDING = 1f;

    [SerializeField] private GameObject playerWeapon;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float projectileCooldown = 0.05f;

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

            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    0,
                    projectileSpeed
                );

            yield return new WaitForSeconds(projectileCooldown);
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
