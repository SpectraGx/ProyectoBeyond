using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    //          VIDA PJ         //
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

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
    private PlayerShootShot playerShootShot;

    //          START           //
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
        playerShootShot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootShot>();


        // Inicializar vida del PJ
        currentHealth = maxHealth;
    }

    //          UPDATE          //
    private void Update()
    {
        movehori = Input.GetAxisRaw("Horizontal") * speedmove;

        //          Animator            //  
        animator.SetFloat("Horizontal", Mathf.Abs(movehori));
        animator.SetBool("Pistola", playerShoot.pistola);
        animator.SetBool("Shotgun", playerShootShot.escopeta);
        animator.SetBool("Num1", playerShoot.num1);
        animator.SetBool("Num2", playerShootShot.num2);

        //          Si la vida baja a 0         //
        if (currentHealth <= 0)
        {
            Die();
        }

        //          Presionar numeros           //
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerShoot.num1 = true;
            playerShootShot.num2 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerShoot.num1 = false;
            playerShootShot.num2 = true;
        }
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

    public void TakeDamageEnemy(int damage)
    {
        currentHealth -= damage;
    }

    private void Die()
    {
        Debug.Log("Has muerto");
        // Mandar a llamar menu de Game Over
    }
}
