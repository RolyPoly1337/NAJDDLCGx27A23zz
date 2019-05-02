using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;


    private Rigidbody2D rb;
   // public SpriteRenderer sr;
    private bool isGrounded;

    public Transform checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private bool facingRight = true;

    // BELOW IS WALLCHECK
    private bool isTouchingWall;
    //private bool isTouchingWallOne;
    public float wallCheckDistance;
    public Transform wallCheck;
    public Transform wallCheckOne;
    private bool isWallSlideActive;
    public float wallSlideSpeed;

    //public Vector2 wallBounceOffDirection;
    //public Vector2 wallJumpDirection;
    //public float wallBounceOffForce;
    //public float wallJumpForce;
    //private int facingDirection = 1;

    // private float knockbackDuration;
    //private float knockbackAmount;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
        // wallBounceOffDirection.Normalize();
        // wallJumpDirection.Normalize();

    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);

        isTouchingWall = Physics2D.Raycast(wallCheck.position,transform.right, wallCheckDistance, whatIsGround);
        //isTouchingWallOne = Physics2D.Raycast(wallCheckOne.position, transform.up, wallCheckDistance, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal") + CrossPlatformInputManager.GetAxisRaw("Horizontal"); ;

        //moveInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if  (isWallSlideActive) { 
        if (rb.velocity.y < -wallSlideSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
        }
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
        CheckIfWallSlide();
        if (isGrounded == true || isWallSlideActive)
        {
            extraJumps = extraJumpsValue;
        }
        /*else if (isWallSlideActive && moveInput == 0 && extraJumps > 0)
        {
            isWallSlideActive = false;
            extraJumps--;
            Vector2 forceToAdd = new Vector2(wallBounceOffForce * wallBounceOffDirection.x * -facingDirection, wallBounceOffForce * wallBounceOffDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        else if ((isWallSlideActive || isTouchingWall) && moveInput != 0 && extraJumps > 0)
        {
            isWallSlideActive = false;
            extraJumps--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * moveInput, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        */
        if ((Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)|| ((CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps > 0)))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
       /* if ((Input.GetKeyUp(KeyCode.UpArrow) && extraJumps > 0) || ((CrossPlatformInputManager.GetButtonUp("Jump") && extraJumps > 0)))
        {
            rb.velocity = Vector2.up * 0.5f;
            extraJumps--;
        }
        */
        if (((Input.GetButtonDown("Jump") && extraJumps > 0)))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
       
        else if ((Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true) )
        {
            rb.velocity = Vector2.up * jumpForce;
       
         }
        /*else if (isWallSlideActive && moveInput == 0 && extraJumps > 0)
        {
            isWallSlideActive = false;
            extraJumps--;
            Vector2 forceToAdd = new Vector2(wallBounceOffForce * wallBounceOffDirection.x * -facingDirection, wallBounceOffForce * wallBounceOffDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        else if ((isWallSlideActive || isTouchingWall) && moveInput != 0 && extraJumps > 0)
        {
            isWallSlideActive = false;
            extraJumps--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * moveInput, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }*/
        
        //CheckIfWallSlide();
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
        //facingDirection *= -1;
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
       // transform.Rotate(0.0f, 180f, 0.0f);
    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        // Gizmos.color = Color.red;
        // Gizmos.DrawLine(wallCheckOne.position, new Vector3(wallCheckOne.position.x + wallCheckDistance, wallCheckOne.position.y, wallCheckOne.position.z));
    }
    private void CheckIfWallSlide()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSlideActive = true;
        }
        else
        {
            isWallSlideActive = false;
        }


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
