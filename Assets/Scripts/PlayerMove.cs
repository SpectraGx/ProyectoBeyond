using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //          VARIABLES           //
    public float speed = 5f;
    private Rigidbody2D rb;

    //          START           //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //          UPDATE          //
    void FixedUpdate()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");
        Vector2 moveVelocity = new Vector2(moveInputX, moveInputY).normalized * speed;
        rb.velocity = moveVelocity;
    }
}
