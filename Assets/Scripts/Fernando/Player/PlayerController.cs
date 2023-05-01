using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    //          MOVIMIENTO          //
    private float movehori = 0f;
    [SerializeField] private float speedmove = 500;
    [Range(0, 0.5f)][SerializeField] private float smoothingmove;
    private Vector3 speed = Vector3.zero;
    private bool viewR = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movehori = Input.GetAxisRaw("Horizontal") * speedmove;
    }

    private void FixedUpdate()
    {
        Move(movehori * Time.fixedDeltaTime);
    }

    private void Move(float mover)
    {
        Vector3 targetspeed = new Vector2(mover, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetspeed, ref speed, smoothingmove);

        if (mover > 0 && !viewR)
        {
            Rotate();
        }
        else if (mover < 0 && viewR)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        viewR = !viewR;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
}
