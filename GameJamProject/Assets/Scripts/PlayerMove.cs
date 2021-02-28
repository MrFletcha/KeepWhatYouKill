using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxJumps;
    public float jumpForce;
    public float speed;
    public Transform groundCheck;
    public LayerMask ground;

    private Rigidbody2D rb;
    private bool isJumping;
    private bool isGrounded;
    private float jumpCount;
    private float movDir;
    private float checkCircle;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        jumpCount = maxJumps;   
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkCircle, ground);
        if (isGrounded)
        {
            jumpCount = maxJumps;
        }
        moving();
    }

    public void Update()
    {
        processingMov();

        if(movDir < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        else if(movDir > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void moving()
    {
        rb.velocity = new Vector2(movDir * speed, rb.velocity.y);
     
        if (isJumping && jumpCount > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jumpCount--;
        }
        isJumping = false;
    }

    private void processingMov()
    {
        movDir = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }
}
