using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MathTowerUiManager : MonoBehaviour
{
    [SerializeField] public Button textBackground;
    [SerializeField] Text _question;
    [SerializeField] Sprite[] _spriteImg;
    [SerializeField] public Image starsImg;
    [SerializeField] public Image congrats;
    [SerializeField] public RawImage confetti;
    [SerializeField] public RawImage _video;
    string[] _questionText;

    public int stars = 0;
    // check if the level end for updating the stars
    public bool isActive = false;
    private bool isFinished = false;
    Scene scene;
    [SerializeField] Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        getQuestion();
        _video.GetComponent<VideoPlayer>().loopPointReached += EndReached;
        _question.text = _questionText[0];
        congrats.gameObject.SetActive(false);
        confetti.gameObject.SetActive(false);
        timer.SetDuration(60).Begin();
        Timer.SetPaused(true);
    }
    private void Update()
    {
        if (isFinished)
        {
            _video.enabled = false;
            Timer.SetPaused(false);
        }
    }

    void EndReached(VideoPlayer vp)
    {
        isFinished = true;
    }

    public void SkipVideo()
    {
        DestroyImmediate(GameObject.Find("Video"));
        Timer.SetPaused(false);
    }

    private void getQuestion()
    {
        if (scene.name == "Math-Level-1")
        {
            _questionText = new string[] { "1 + 1", "2 + 3", "7 + 1" };
           
        }
        else if (scene.name == "Math-Level-2")
        {
            _questionText = new string[] { "1 - 1", "6 - 4", "7 - 1" };
        }
        else if (scene.name == "Math-Level-3")
        {
            _questionText = new string[] { "1 + 4", "4 - 3", "6 + 1" };
        }
        else if (scene.name == "Math-Level-4")
        {
            _questionText = new string[] { "1 > 9", "2 > 3", "8 > 9" };
        }
        else
        {
            _questionText = new string[] { "6 < 5", "2 < 7", "6 < 1" };
        }
    }

    // Update is called once per frame
    public void UpdateQuestion(int index)
    {
        _question.text = _questionText[index];
    }

    public void UpdateStars(int second, bool isActive)
    {
        //int stars = 0;
        if (isActive)
        {
            if (second >= 45)
            {
                starsImg.sprite = _spriteImg[3];
                stars = 3;
                
            }
            else if (second >= 30)
            {
                starsImg.sprite = _spriteImg[2];
                stars = 2;
            }
            else
            {
                starsImg.sprite = _spriteImg[1];
                stars = 1;
            }
            //Stars.instance.starsNumber = stars;
            //Debug.Log("stars =" + Stars.instance.starsNumber);
        }
    }
    public IEnumerator FinishingLevel()
    {
        yield return new WaitForSeconds(0.7f);
        // the white rect that contain the question
        textBackground.gameObject.SetActive(false);
        Timer.SetPaused(true);
        yield return new WaitForSeconds(0.3f);
        // finishing level Screen
        congrats.gameObject.SetActive(true);
        //UpdateStars(Timer.second, isActive);
        isActive = true;
        // confetti is the finishing video
        confetti.gameObject.SetActive(true);
    }
}
