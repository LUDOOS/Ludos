using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathTowerPlayer : MonoBehaviour
{
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
            rb.velocity = new Vector2(rb.velocity.x,_jumpForce);
            StartCoroutine(jumpAnimate());
            isGrounded = false;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "BARRIER")
        {
           isGrounded = true;
        }
        StartCoroutine(barrier(collision));
    }

    IEnumerator barrier(Collision2D collision)
    {
        GameObject _barrier = collision.gameObject;

        if (_barrier.name == "2" || _barrier.name == "5" || _barrier.name == "8")
        {
            GameObject _barrierChild = _barrier.transform.GetChild(0).gameObject;
            _barrierChild.SetActive(false);
            yield return new WaitForSeconds(0.7f);
            if (_barrier.name == "2")
            {
                uiManager.updateQuestion(1);
                if (scene.name == "Level-1" || scene.name == "Level-3" || scene.name == "Level-4" || scene.name == "Level-5") {
                    _barrier.GetComponent<Animator>().Play("ScalingToRight");
                }
                else
                {
                    _barrier.GetComponent<Animator>().Play("ScalingToLeft");
                }
                Destroy(wrongBarrier1);
            }
            if (_barrier.name == "5")
            {
                uiManager.updateQuestion(2);
                if (scene.name == "Level-1" || scene.name == "Level-3" || scene.name == "Level-5")
                {
                    _barrier.GetComponent<Animator>().Play("ScalingToLeft");
                }
                else
                {
                    _barrier.GetComponent<Animator>().Play("ScalingToRight");
                }
                Destroy(wrongBarrier2);
            }
            if (_barrier.name == "8")
            {
                if (scene.name == "Level-1" || scene.name == "Level-2" || scene.name == "Level-5")
                {
                    _barrier.GetComponent<Animator>().Play("ScalingToLeft");
                }
                else
                {
                    _barrier.GetComponent<Animator>().Play("ScalingToRight");
                }
                Destroy(wrongBarrier3);
                yield return new WaitForSeconds(0.7f);
                uiManager.textBackground.gameObject.SetActive(false);
                Timer.SetPaused(true);
                yield return new WaitForSeconds(0.3f);
                uiManager.congrates.gameObject.SetActive(true);
                uiManager.updateStars(Timer.second);
                uiManager.confetti.enabled = true;
                MathTowerGameManager.instance.isCompleted = true;
            }
        }
        else if(_barrier.name == "1" || _barrier.name == "4" || _barrier.name == "6")
        {
            yield return new WaitForSeconds(1.5f);
            _barrier.AddComponent<Rigidbody2D>().gravityScale = 1;
            //_wrongBarrier.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}
