using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerControllerone : MonoBehaviour {

    private float movementInputDirection;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isWalking;
    private bool isTouchingWall;

    public float movementSpeed;

    private bool isFacingRight = true;
    public float jumpForce;

    public Transform checkGround;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool canJump;
    private int extraJumpsRemainder;
    public int extraJumpsValue;
    public float JumpHeightMultiplier;

    public float wallCheckDistance;
    public Transform wallCheck;
    private bool isWallSlideActive;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragForceAmount;

    public Vector2 wallBounceOffDirection;
    public Vector2 wallJumpDirection;
    public float wallBounceOffForce;
    public float wallJumpForce;
    private int facingDirection = 1;

    public Vector2 wallJumpDirectionAdditionalForClimbing;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        extraJumpsRemainder = extraJumpsValue;
        wallBounceOffDirection.Normalize();
        wallJumpDirection.Normalize();

    }
	
	// Update is called once per frame
	void Update () {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSlideActive();

    }
    private void FixedUpdate()
    {
        MovementController();
        CheckSurroundings();
    }
    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
        if (rb.velocity.x != 0)
        {
        isWalking = true;
        }
        isWalking = false;
    }


    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }


    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
    }


    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal") + CrossPlatformInputManager.GetAxisRaw("Horizontal"); 

        if ((Input.GetKeyDown(KeyCode.UpArrow)||((CrossPlatformInputManager.GetButtonDown("Jump") ||(Input.GetButtonDown("Jump"))))))
        {
            Jump();
        }
        if ((Input.GetKeyUp(KeyCode.UpArrow)||((CrossPlatformInputManager.GetButtonUp("Jump") || (Input.GetButtonUp("Jump"))))))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * JumpHeightMultiplier);
        }
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0 || isWallSlideActive)
        {
            extraJumpsRemainder = extraJumpsValue;
        }

        if (isWallSlideActive)
        {
            extraJumpsRemainder = 1;
            Debug.Log("4");
        }
        if (extraJumpsRemainder <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }


    private void Jump()
    {
        if (!isGrounded && isTouchingWall && !isWallSlideActive && movementInputDirection == 1 && facingDirection == 1 && canJump)
        {
            // canJump = false;
            extraJumpsRemainder = 0;
            isWallSlideActive = true;
            extraJumpsRemainder = 0;
            isWallSlideActive = false;
            extraJumpsRemainder--;
            movementInputDirection = -1;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirectionAdditionalForClimbing.x * movementInputDirection, wallJumpForce * wallJumpDirectionAdditionalForClimbing.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            movementInputDirection = -1;
            movementInputDirection = -1;
            movementInputDirection = -1;
            Debug.Log("from");
        }
        else if (!isGrounded && isTouchingWall && !isWallSlideActive && movementInputDirection == -1 && facingDirection == -1 && canJump)
        {
            extraJumpsRemainder = 0;
            isWallSlideActive = true;
            extraJumpsRemainder = 0;
            isWallSlideActive = false;
            extraJumpsRemainder--;
            movementInputDirection = 1;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirectionAdditionalForClimbing.x * movementInputDirection, wallJumpForce * wallJumpDirectionAdditionalForClimbing.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            movementInputDirection = 1;
            movementInputDirection = 1;
            movementInputDirection = 1;

            Debug.Log("1a");
            Debug.Log("4.5a");
        }

        if (canJump && !isWallSlideActive)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            extraJumpsRemainder--;
            Debug.Log("1");
        }
        else if (isWallSlideActive && movementInputDirection == 0 && canJump)
        {
            isWallSlideActive = false;
            extraJumpsRemainder--;
            Vector2 forceToAdd = new Vector2(wallBounceOffForce * wallBounceOffDirection.x * -facingDirection, wallBounceOffForce * wallBounceOffDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            Debug.Log("2");
        }
        else if ((isWallSlideActive || isTouchingWall) && movementInputDirection == 1 && facingDirection == 1 && canJump)
        {
            // extraJumpsRemainder = 0;
            //isWallSlideActive = true;
            extraJumpsRemainder = 0;
            //isWallSlideActive = false;
            extraJumpsRemainder--;
            movementInputDirection = -1;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirectionAdditionalForClimbing.x * movementInputDirection, wallJumpForce *  wallJumpDirectionAdditionalForClimbing.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            movementInputDirection = -1;
            movementInputDirection = -1;
            movementInputDirection = -1;
            Debug.Log("1");
            Debug.Log("3.5");
        }
        else if ((isWallSlideActive || isTouchingWall) && movementInputDirection == -1 && facingDirection == -1 && canJump)
        {
            // extraJumpsRemainder = 0;
            //isWallSlideActive = true;
            extraJumpsRemainder = 0;
            //isWallSlideActive = false;
            extraJumpsRemainder--;
            movementInputDirection = 1;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirectionAdditionalForClimbing.x * movementInputDirection, wallJumpForce * wallJumpDirectionAdditionalForClimbing.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            movementInputDirection = 1;
            movementInputDirection = 1;
            movementInputDirection = 1;
            Debug.Log("1");
            Debug.Log("4.5");
        }
        else if ((isWallSlideActive || isTouchingWall) && movementInputDirection != 0 && canJump)
        {
            extraJumpsRemainder = 0;
            isWallSlideActive = false;
            extraJumpsRemainder--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            Debug.Log("3");
            
        }
    }


    private void MovementController()
    {
        
       
    

        if (isGrounded)
        {
            rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        }

        else if (!isGrounded && !isWallSlideActive && movementInputDirection != 0)
        {
            Vector2 forcetoAdd = new Vector2(movementForceInAir * movementInputDirection, 0);
            rb.AddForce(forcetoAdd);

            if(Mathf.Abs(rb.velocity.x) > movementSpeed)
            {
                rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
            }
        }

        else if (!isGrounded && !isWallSlideActive && movementInputDirection == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragForceAmount, rb.velocity.y);
        }

        if (isWallSlideActive)
        {
            if (rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }
    }
  


    
    private void CheckIfWallSlideActive()
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


    private void Flip()
    {
        if (!isWallSlideActive)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180f, 0.0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGround.position, checkRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));

    }
}
