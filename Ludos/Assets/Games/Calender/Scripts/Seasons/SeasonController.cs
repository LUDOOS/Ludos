using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeasonController : MonoBehaviour
{
    CameraLerp mainCam;

    private int StarCounter = 0;
    public Image img;
    public Sprite[] sprites;
    AnimationController animationController;
    AudioController audioController;
    static bool[] completeStatus = { false, false, false, false }; // -------------->>> LevelProgress
    public Button[] answerButtons;



    Vector3[,] pageLocations = new[,] {
        { new Vector3(-0.7f, 0, -10),new Vector3(-0.7f, 0f, 0) },
        { new Vector3(6f, 0, -10),new Vector3(6, 0f, 0) }, //Second Question Pos
        { new Vector3(11.68f, 0, -10),new Vector3(11.68f, 0f, 0) }, //third Question Page Pos
        { new Vector3(16.4f, 0, -10),new Vector3(16.55f, 3.52f, 0) }
    };
    // Start is called before the first frame update
    void Start()
    {

        mainCam = GameObject.Find("MainCamParent").GetComponent<CameraLerp>();
        audioController = GameObject.Find("Audio Source").GetComponent<AudioController>();
        animationController = GameObject.Find("AnimationController").GetComponent<AnimationController>();

    }


    public void goToQuestion_one()
    {
        StartCoroutine(mainCam.LerpFromTo(pageLocations[0, 0], 2f, 0f));
        StartCoroutine(mainCam.LerpFromTo("avatarParent", pageLocations[0, 1], 1.5f, 0f));
        audioController.audioSource.Stop();
        audioController.ChangeClip(1);
    }
    public void goToQuestion_two(bool correct)
    {
        disableKeys(answerButtons[0], answerButtons[1]);
        if (!correct)
        {
            animationController.animateCamera("wrongAnswer");
        }
        else
        {
            animationController.animate("correctAnswer", "avatar1");
            StarCounter++;
        }

        StartCoroutine(mainCam.LerpFromTo(pageLocations[1, 0], 2f, 1.2f));
        StartCoroutine(mainCam.LerpFromTo("avatarParent", pageLocations[1, 1], 1.5f, 1.2f));
        audioController.audioSource.Stop();
        audioController.ChangeClip(2);
    }

    public void goToQuestion_three(bool correct)
    {
        disableKeys(answerButtons[2], answerButtons[3]);
        if (!correct)
        {
            animationController.animateCamera("wrongAnswer");
        }
        else
        {
            animationController.animate("correctAnswer", "avatar1");
            StarCounter++;
        }
        StartCoroutine(mainCam.LerpFromTo(pageLocations[2, 0], 2f, 1.2f));
        StartCoroutine(mainCam.LerpFromTo("avatarParent", pageLocations[2, 1], 1.5f, 1.2f));
        audioController.audioSource.Stop();
        audioController.ChangeClip(3);
    }
    public void goToFinalPage(bool correct)
    {
        disableKeys(answerButtons[4], answerButtons[5]);
        if (!correct)
        {
            animationController.animateCamera("wrongAnswer");

        }
        else
        {
            animationController.animate("correctAnswer", "avatar1");
            StarCounter++;
        }
        updateFinalPage();
        UpdateLevels(); // -------------->>> LevelProgress
        StartCoroutine(mainCam.LerpFromTo(pageLocations[3, 0], 2f, 1.2f));
        StartCoroutine(mainCam.LerpFromTo("avatarParent", pageLocations[3, 1], 1.5f, 1.2f));
        audioController.audioSource.Stop();
        //audioController.ChangeClip(1);
    }



    public void updateFinalPage()
    {
        if (StarCounter == 3)
        {
            img.sprite = sprites[3];
            
        }
        else if (StarCounter == 2)
        {
            img.sprite = sprites[2];
            
        }
        else if (StarCounter == 1)
        {
            img.sprite = sprites[1];
            
        }
        else if (StarCounter == 0)
        {
            img.sprite = sprites[0];
            
        }


    }
        void UpdateLevels() // -------------->>> LevelProgress
    {
            if (!completeStatus[GameManager.instance.CalendarCurrentLevel-4] && GameManager.instance.CalendarNextLevel != GameManager.instance.CalendarCurrentLevel)
            {
                completeStatus[GameManager.instance.CalendarCurrentLevel-4] = true;
            GameManager.instance.UpdateData(GameName: "Calendar",
                level: GameManager.instance.CalendarCurrentLevel ,
                stars: StarCounter);
        }


        }
        void disableKeys(Button b1, Button b2)
        {
            b1.interactable = false;
            b2.interactable = false;

        }

}


