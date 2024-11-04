using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 5f;
    public float zeroGravitySpeed = 2f;
    public float jumpForce = 3f;
    private float originalGravityScale;
    private bool grounded = true;
    private Animator animator;
    public ZeroGravityTimer zeroGravityTimer;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(!zeroGravityTimer.isZeroGravity)
        {
            rb.gravityScale = originalGravityScale;
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if(horizontalInput > 0.01f)
            {
                transform.localScale = rb.gravityScale < 0 ? new Vector3(1, -1, 1) : Vector3.one;
            }
            else if(horizontalInput < -0.01f)
            {
                transform.localScale = rb.gravityScale < 0 ? new Vector3(-1, -1, 1) : new Vector3(-1, 1, 1);
            }
            else
            {
                Vector3 temp = transform.localScale;
                temp.y = rb.gravityScale < 0 ? -1f : 1f;
                transform.localScale = temp;
            }

            if(Input.GetKey(KeyCode.Space) && grounded)
            {
                Jump();
            }

            if(Input.GetKeyDown(KeyCode.R) && grounded)
            {
                originalGravityScale *= -1;
                jumpForce *= -1;
                grounded = false;
            }

            animator.SetBool("isFloating", false);
            animator.SetBool("isRunning", horizontalInput != 0);
        }
        else
        {
            rb.gravityScale = 0f;
            animator.SetBool("isFloating", true);
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = verticalInput != 0 ? new Vector2(horizontalInput * zeroGravitySpeed, verticalInput * zeroGravitySpeed) : new Vector2(horizontalInput * zeroGravitySpeed, 0.2f);

            if(horizontalInput > 0.01f)
            {
                if(verticalInput < 0)
                {
                    transform.localScale = new Vector3(1, -1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else if(horizontalInput < -0.01f)
            {
                if(verticalInput < 0)
                {
                    transform.localScale = new Vector3(-1, -1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, -1, 1);
                }
            }
            else
            {
                Vector3 temp = transform.localScale;
                if(verticalInput < 0)
                {
                    temp.y = -1f;
                }
                else if(verticalInput > 0)
                {
                    temp.y = 1f;
                }
                transform.localScale = temp;
            }
            animator.SetBool("isFlyingHorizontal", horizontalInput != 0);
            animator.SetBool("isFlyingVertical", verticalInput != 0);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        grounded = false;
        animator.SetBool("isGrounded", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platform"))
        {
            grounded = true;
            animator.SetBool("isGrounded", true);
        }
    }
}