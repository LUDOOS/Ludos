using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathTowerPlayer : MonoBehaviour
{
    // if the player touch the ground and the TouchingBarrier
    public bool isGrounded = true;
    float _movement = 2.5f;
    float _jumpForce = 8.3f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    MathTowerUiManager uiManager;
    Scene scene;
    [SerializeField] private GameObject wrongBarrier1;
    [SerializeField] private GameObject wrongBarrier2;
    [SerializeField] private GameObject wrongBarrier3;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<MathTowerUiManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene();
    }

    IEnumerator walkAnimate()
    {
        animator.SetBool("Walk",true);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "BARRIER")
        {
           isGrounded = true;
        }
        StartCoroutine(TouchingBarrier(collision));
    }

    IEnumerator TouchingBarrier(Collision2D collision)
    {
        GameObject barrier = collision.gameObject;

        if (barrier.name == "2" || barrier.name == "5" || barrier.name == "8")
        {
            RemoveTheAnswerImage(barrier);
            yield return new WaitForSeconds(0.7f);
            AnimateBarrier(barrier);
        }
        // this section caused *Null Reference Exception*
        else if (barrier.name == "1" || barrier.name == "4" || barrier.name == "6")
        {
            yield return new WaitForSeconds(1.5f);
            barrier.AddComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(1f);
        }
    }

    private void AnimateBarrier(GameObject barrier)
    {
        if (barrier.name == "2")
        {
            // Update Question
            uiManager.UpdateQuestion(1);
            // Animate Barrier Based on Level
            if (scene.name == "Level-1" || scene.name == "Level-3" || scene.name == "Level-4" || scene.name == "Level-5")
            {
                barrier.GetComponent<Animator>().Play("ScalingToRight");
            }
            else
            {
                barrier.GetComponent<Animator>().Play("ScalingToLeft");
            }
            // Destroy the Wrong Barrier in Case the
            // player jump on the correct barrier
            Destroy(wrongBarrier1);
        }
        if (barrier.name == "5")
        {
            uiManager.UpdateQuestion(2);
            if (scene.name == "Level-1" || scene.name == "Level-3" || scene.name == "Level-5")
            {
                barrier.GetComponent<Animator>().Play("ScalingToLeft");
            }
            else
            {
                barrier.GetComponent<Animator>().Play("ScalingToRight");
            }
            Destroy(wrongBarrier2);
        }
        if (barrier.name == "8")
        {
            if (scene.name == "Level-1" || scene.name == "Level-2" || scene.name == "Level-5")
            {
                barrier.GetComponent<Animator>().Play("ScalingToLeft");
            }
            else
            {
                barrier.GetComponent<Animator>().Play("ScalingToRight");
            }
            Destroy(wrongBarrier3);
            StartCoroutine(uiManager.FinishingLevel());
        }
    }

    private void RemoveTheAnswerImage(GameObject barrier)
    {
        GameObject barrierChild = barrier.transform.GetChild(0).gameObject;
        barrierChild.SetActive(false);
    }
}
