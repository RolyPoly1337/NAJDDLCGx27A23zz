﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;


    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private bool isGrounded;

    public Transform checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private bool facingRight = true;

   // private float knockbackDuration;
    //private float knockbackAmount;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal") + CrossPlatformInputManager.GetAxisRaw("Horizontal"); ;
        //moveInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }
    void Update()
    {
        if (isGrounded == true) {
            extraJumps = extraJumpsValue;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0) || ((CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps > 0)))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        if (((Input.GetButtonDown("Jump") && extraJumps > 0)))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
           /* if (moveInput > 0)
        {
            sr.flipX = false;
        }
        else if (moveInput < 0)
        {
            sr.flipX = true;
        }*/
    }
    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    /*public IEnumerator Knockback (float knockbackDuration, float knockbackAmount, Vector3 knockbackPosition)
    {
        float timer = 0;
        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackPosition.x * -100, knockbackPosition.y, transform.position.z));
        }
       yield return 0;
    }
    */

}
