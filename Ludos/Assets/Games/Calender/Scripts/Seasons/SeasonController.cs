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
    public TextMeshProUGUI txt;
    AnimationController animationController;
    AudioController audioController;

    Vector3[,] pageLocations = new[,] {
        { new Vector3(-0.7f, 0, -10),new Vector3(-0.7f, 0f, 0) },
        { new Vector3(6f, 0, -10),new Vector3(6, 0f, 0) }, //Second Question Pos
        { new Vector3(11.68f, 0, -10),new Vector3(11.68f, 0f, 0) }, //third Question Page Pos
        { new Vector3(16.4f, 0, -10),new Vector3(16.34f, 2.71f, 0) }
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
            txt.text = "Well Done You got Them All Right !";
        }
        else if (StarCounter == 2)
        {
            img.sprite = sprites[2];
            txt.text = "Good Job You got 2 correctly !!";
        }
        else if (StarCounter == 1)
        {
            img.sprite = sprites[1];
            txt.text = "Good Job You only Got One Right";
        }
        else if (StarCounter == 0)
        {
            img.sprite = sprites[0];
            txt.text = "You should rewatch the Story Video";
        }


    }


}


