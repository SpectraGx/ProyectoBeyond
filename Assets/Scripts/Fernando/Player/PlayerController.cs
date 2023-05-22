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

    //          ANIMATOR            //
    private Animator animator;

    //          REFERENCIAS CLASES          //
    private PlayerShoot playerShoot;

    //          START           //
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();

    }

    //          UPDATE          //
    private void Update()
    {
        movehori = Input.GetAxisRaw("Horizontal") * speedmove;
        animator.SetFloat("Horizontal", Mathf.Abs(movehori));
        animator.SetBool("Pistola",playerShoot.pistola);
    }

    //          FIXEDUPDATE         //
    private void FixedUpdate()
    {
        Move(movehori * Time.fixedDeltaTime);
    }

    //          METODO MOVE           //
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

    //          METODO ROTATE           //
    private void Rotate()
    {
        viewR = !viewR;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
}
