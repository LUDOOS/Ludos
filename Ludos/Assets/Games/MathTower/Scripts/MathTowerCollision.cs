using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTowerCollision : MonoBehaviour
{
    MathTowerController _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GameObject.Find("Player").GetComponent<MathTowerController>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TouchingBarrier(collision));
    }

    IEnumerator TouchingBarrier(Collision2D collision)
    {
        GameObject barrier = collision.gameObject;

        if (barrier.name == "2" || barrier.name == "5" || barrier.name == "8")
        {
            _controller.RemoveTheAnswerImage(barrier);
            yield return new WaitForSeconds(0.7f);
            _controller.AnimateBarrier(barrier);
        }
        // this section caused *Null Reference Exception* // 
        else if (barrier.name == "1" || barrier.name == "4" || barrier.name == "6")
        {
            yield return new WaitForSeconds(1.5f);
            barrier.AddComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(1f);
            Destroy(barrier);
        }
    }
}
