using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathTowerController : MonoBehaviour
{
    [SerializeField] private GameObject[] wrongBarrier;
    static bool[] completeStatus = { false, false, false, false, false };
    MathTowerUiManager uiManager;
    private int stars = 0;
    Scene scene;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<MathTowerUiManager>();
        scene = SceneManager.GetActiveScene();
    }

    public void AnimateBarrier(GameObject barrier)
    {
        FirstBarrier(barrier);
        SecondBarrier(barrier);
        ThirdBarrier(barrier);
    }

    private void FirstBarrier(GameObject barrier)
    {
        if (barrier.name == "2")
        {
            // Update Question
            uiManager.UpdateQuestion(1);
            // Animate Barrier Based on Level
            if (scene.name == "Math-Level-1" || scene.name == "Math-Level-3" || scene.name == "Math-Level-4" || scene.name == "Math-Level-5")
            {
                //stars++;
                barrier.GetComponent<Animator>().Play("ScalingToRight");
            }
            else
            {
                barrier.GetComponent<Animator>().Play("ScalingToLeft");
            }
            // Destroy the Wrong Barrier in Case the
            // controller jump on the correct barrier
            Destroy(wrongBarrier[0]);
        }
    }

    private void SecondBarrier(GameObject barrier)
    {
        if (barrier.name == "5")
        {
            uiManager.UpdateQuestion(2);
            if (scene.name == "Math-Level-1" || scene.name == "Math-Level-3" || scene.name == "Math-Level-5")
            {
               // stars++;
                barrier.GetComponent<Animator>().Play("ScalingToLeft");
            }
            else
            {
                barrier.GetComponent<Animator>().Play("ScalingToRight");
            }
            Destroy(wrongBarrier[1]);
        }
    }

    private void ThirdBarrier(GameObject barrier)
    {
        if (barrier.name == "8")
        {
            if (scene.name == "Math-Level-1" || scene.name == "Math-Level-2" || scene.name == "Math-Level-5")
            {
                // stars++;
                barrier.GetComponent<Animator>().Play("ScalingToLeft");
            }
            else
            {
                barrier.GetComponent<Animator>().Play("ScalingToRight");
            }
            Destroy(wrongBarrier[2]);
            //StartCoroutine(uiManager.FinishingLevel());
            StartCoroutine(UpdateLevels());
        }
    }

    public void RemoveTheAnswerImage(GameObject barrier)
    {
        GameObject barrierChild = barrier.transform.GetChild(0).gameObject;
        barrierChild.SetActive(false);
    }
    IEnumerator UpdateLevels()
    {
        yield return StartCoroutine(uiManager.FinishingLevel());
        uiManager.UpdateStars(Timer.second, isActive:uiManager.isActive);
        if (!completeStatus[GameManager.instance.mathTowerCurrentLevel])
        {
            
            completeStatus[GameManager.instance.mathTowerCurrentLevel] = true;
            //int level= int.Parse(scene.name[^1].ToString())-1;
            //Debug.Log($"level mathtower {level}");
            GameManager.instance.UpdateData(GameName:"math",level: GameManager.instance.mathTowerCurrentLevel, stars:uiManager.stars);
        }
        
        
    }
}
