using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal"); //стрілки або A/D
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}