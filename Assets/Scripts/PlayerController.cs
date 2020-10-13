using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public Animator animator;
    private float gravity;
    
    //Terrain check variables
    public bool isGrounded;
    public Transform feetpos;
    private bool isBonk;
    public Transform headpos;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    //Jumping variables
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public float jumpSpeedMultiplier;
    public float jumpFallMultiplier;
    public int jumpCounter;
    public float doubleJumpMultiplier;

    //Dashing variables
    private float moveSpeed;
    public float dashMultiplier;
    public float dashTime;
    private float dashTimeCounter;
    private bool dashReady = true;
    private bool isDashOngoing;
    public float dashCooldown;
    private float dashCooldownCounter;
    private bool isDashing = false;


    //Direction variables
    private bool facingRight;
    private bool facingLeft;

    //skill aquired variables
    public bool aquiredDash = false,
                aquiredDoubleJump = false;

    //Interactions status check variables
    public bool isStaticInteraction,
                 isDynamicInteraction;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        jumpCounter = 0;
        facingRight = true;
    }

    void FixedUpdate()
    {
        if (!isStaticInteraction)
        {
            if (isDashing == false && dashReady == true)
            {
                dashTimeCounter = dashTime;
                dashCooldownCounter = dashCooldown + dashTime;
            }


            if (isDashing == true && dashTimeCounter > 0 && facingRight == true && aquiredDash == true)
            {
                rb.velocity = new Vector2(1 * speed * dashMultiplier, rb.velocity.y);
                moveSpeed = rb.velocity.x;
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
                dashTimeCounter -= Time.fixedDeltaTime;
                dashReady = false;
                isDashOngoing = true;
            }
            else if (isDashing == true && dashTimeCounter > 0 && facingLeft == true && aquiredDash == true)
            {
                rb.velocity = new Vector2(-1 * speed * dashMultiplier, rb.velocity.y);
                moveSpeed = rb.velocity.x;
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
                dashTimeCounter -= Time.fixedDeltaTime;
                dashReady = false;
                isDashOngoing = true;
            }
            else
            {
                moveInput = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                moveSpeed = rb.velocity.x;
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
                isDashing = false;
                isDashOngoing = false;
            }

            if (dashReady == false && dashCooldownCounter > 0)
            {
                dashCooldownCounter -= Time.fixedDeltaTime;
            }
            else
            {
                dashReady = true;
            }
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);
        isBonk = Physics2D.OverlapCircle(headpos.position, checkRadius, whatIsGround);
        if (!isStaticInteraction)
        {
            if (Input.GetButtonDown("Dash"))
            {
                isDashing = true;
            }

            if (isDashOngoing == true)
            {
                rb.gravityScale = 0;
            }
            else if (isDashOngoing == false)
            {
                rb.gravityScale = gravity;
            }

            if (moveInput > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
                facingLeft = false;
            }
            else if (moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                facingLeft = true;
                facingRight = false;
            }


            
            if (isGrounded == true)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                jumpTimeCounter = jumpTime;
                isJumping = false;
                jumpCounter = 0;
            }


            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                isGrounded = false;
            } 
            else if (Input.GetButtonDown("Jump") && jumpCounter == 1 && aquiredDoubleJump == true)
            {
                jumpTimeCounter = jumpTime * doubleJumpMultiplier;
            }

            if (isGrounded == false && rb.velocity.y <= 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
            }
            else if (isGrounded == false && rb.velocity.y > 0)
            {
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsFalling", false);
            }


            if (Input.GetButtonUp("Jump") && isJumping == true || isBonk == true && isJumping == true)
            {
                jumpCounter += 1;
                jumpTimeCounter = 0;
                isJumping = false;
            }

            if (isGrounded == false && !Input.GetButton("Jump"))
            {
                if (jumpCounter == 0)
                {
                    jumpCounter += 1;
                }
                else
                {
                    jumpTimeCounter = 0;
                }
            }
            else if (isGrounded == false && Input.GetButton("Jump") && jumpTimeCounter > 0)
            {
                isJumping = true;
                rb.velocity = Vector2.up * jumpForce * jumpSpeedMultiplier;
                jumpTimeCounter -= Time.fixedDeltaTime;
            }

        }

        
    }

}
