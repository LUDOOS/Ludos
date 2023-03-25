using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    // Update is called once per frame

    public void animateCamera(string animationName) {

        switch (animationName) {
            case "wrongAnswer":
                animator.SetTrigger("wrongAnswer");
                break;


                
        }
    }
    public void animate(string animationName, string ComponentName) { 
        
        Animator temp = GameObject.Find(ComponentName).GetComponent<Animator>();

        switch (animationName)
        {
            case "UI1_enable":
                temp.SetTrigger("click");
                break;
            case "UI2_enable":
                temp.SetTrigger("click2");
                break;
            case "correctAnswer":
                temp.SetTrigger("correct");
                break;
        }
    }
}
