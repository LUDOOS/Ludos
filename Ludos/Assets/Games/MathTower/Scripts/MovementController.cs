using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public bool isGrounded = true;
    float _movement = 2.5f;
    float _jumpForce = 8.3f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "BARRIER")
        {
            isGrounded = true;
        }
    }

    IEnumerator walkAnimate()
    {
        animator.SetBool("Walk", true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("Walk", false);
    }

    IEnumerator jumpAnimate()
    {
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("Jump", false);
    }

    public void leftMove()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(-_movement, rb.velocity.y);
            StartCoroutine(walkAnimate());
            sr.flipX = true;
        }
    }

    public void rightMove()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(_movement, rb.velocity.y);
            StartCoroutine(walkAnimate());
            sr.flipX = false;
        }
    }

    public void jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            StartCoroutine(jumpAnimate());
            isGrounded = false;
            //isActive = false;
        }

    }
}
