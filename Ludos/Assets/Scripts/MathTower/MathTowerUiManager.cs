using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathTowerUiManager : MonoBehaviour
{
    [SerializeField] public Button textBackground;
    [SerializeField] Text _question;
    [SerializeField] Sprite[] _spriteImg;
    [SerializeField] Image _starsImg;
    [SerializeField] public Image congrates;
    [SerializeField] public RawImage confetti;
    string[] _questionText;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        getQuestion();

        _question.text = _questionText[0];
        congrates.gameObject.SetActive(false);
        confetti.enabled = false;
    }

    private void getQuestion()
    {
        if (scene.name == "Level-1")
        {
            _questionText = new string[] { "1 + 1", "2 + 3", "7 + 1" };
            MathTowerGameManager.instance.level = 1;
        }
        else if (scene.name == "Level-2")
        {
            _questionText = new string[] { "1 - 1", "6 - 4", "7 - 1" };
            MathTowerGameManager.instance.level = 2;
        }
        else if (scene.name == "Level-3")
        {
            _questionText = new string[] { "1 + 4", "4 - 3", "6 + 1" };
            MathTowerGameManager.instance.level = 3;
        }
        else if (scene.name == "Level-4")
        {
            _questionText = new string[] { "1 > 9", "2 > 3", "8 > 9" };
            MathTowerGameManager.instance.level = 4;
        }
        else
        {
            _questionText = new string[] { "6 < 5", "2 < 7", "6 < 1" };
            MathTowerGameManager.instance.level = 5;
        }
    }

    // Update is called once per frame
    public void updateQuestion(int index)
    {
        _question.text = _questionText[index];
    }

    public void updateStars(int second, bool isActive)
    {
        if (isActive)
        {
            if (second >= 45)
            {
                _starsImg.sprite = _spriteImg[3];
                Stars.instance.starsNumber += 3;
            }
            else if (second >= 30)
            {
                _starsImg.sprite = _spriteImg[2];
                Stars.instance.starsNumber += 2;
            }
            else
            {
                _starsImg.sprite = _spriteImg[1];
                Stars.instance.starsNumber += 1;
            }
        }
    }

}
