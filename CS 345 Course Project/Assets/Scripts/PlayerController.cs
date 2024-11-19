using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 3f;
    private bool grounded = true;
    private Animator animator;
    public bool reversePower = false;
    private Vector2 screenBounds;
    private float playerHalfWidth;
    public int level = 0;

    public bool keyItemCollected = false;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if(level > 1)
        {
            reversePower = true;
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;

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

        if(Input.GetKeyDown(KeyCode.R) && grounded && reversePower)
        {
            ReverseGravity();
        }
        animator.SetBool("isRunning", horizontalInput != 0);

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        grounded = false;
        animator.SetBool("isGrounded", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("movable"))
        {
            grounded = true;
            animator.SetBool("isGrounded", true);
        }
    }

    public void ReverseGravity()
    {
        rb.gravityScale *= -1;
        jumpForce *= -1;
        grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("collectible"))
        {
            keyItemCollected = true;
            Destroy(other.gameObject);
        }
    }
}