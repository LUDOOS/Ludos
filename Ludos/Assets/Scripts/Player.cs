using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded = true;
    float _movement = 2.5f;
    float _jumpForce = 8.3f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    UiManager uiManager;
    [SerializeField] private GameObject wrongBarrier1;
    [SerializeField] private GameObject wrongBarrier2;
    [SerializeField] private GameObject wrongBarrier3;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void leftMove()
    {
        if (isGrounded)
        {
             rb.velocity = new Vector2(-_movement, rb.velocity.y);
            //sr.flipX = true;
        }
       
    }

    public void rightMove()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(_movement, rb.velocity.y);
            //sr.flipX = true;
        }

    }
    public void jump() 
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,_jumpForce);
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
        //if (_barrier.GetComponent<Animator>() != null) {
        //    _barrier.GetComponent<Animator>().SetBool("Idle", true);
        //}
        
           if (_barrier.name == "2" || _barrier.name == "5" || _barrier.name == "8")
        {
            GameObject _barrierChild = _barrier.transform.GetChild(0).gameObject;
            _barrierChild.SetActive(false);
            yield return new WaitForSeconds(0.7f);
            if (_barrier.name == "2")
            {
                uiManager.updateQuestion(1);
                _barrier.GetComponent<Animator>().Play("ScalingToRight");
                Destroy(wrongBarrier1);
            }
            if (_barrier.name == "5")
            {
                uiManager.updateQuestion(2);
                _barrier.GetComponent<Animator>().Play("ScalingToLeft");
                Destroy(wrongBarrier2);
            }
            if (_barrier.name == "8")
            {
                _barrier.GetComponent<Animator>().Play("ScalingToLeft");
                Destroy(wrongBarrier3);
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
