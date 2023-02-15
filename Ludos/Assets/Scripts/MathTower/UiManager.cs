using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] public Button textBackground;
    [SerializeField] Text _question;
    [SerializeField] Sprite[] _spriteImg;
    [SerializeField] Image _starsImg;
    [SerializeField] public Image congrates;
    string[] _questionText;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level-1")
        {
             _questionText = new string[] { "1 + 1", "2 + 3", "7 + 1"};
        }
        else if (scene.name == "Level-2")
        {
            _questionText = new string[] { "1 - 1", "6 - 4", "7 - 1" };
        }
        else if (scene.name == "Level-3")
        {
            _questionText = new string[] { "1 + 4", "4 - 3", "6 + 1" };
        }
        else if (scene.name == "Level-4")
        {
            _questionText = new string[] { "1 > 9", "2 > 3", "8 > 9" };
        }
        else
        {
            _questionText = new string[] { "6 < 5", "2 < 7", "6 < 1" };
        }
        _question.text = _questionText[0];
        congrates.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void updateQuestion(int index)
    {
        _question.text = _questionText[index];
    }

    public void updateStars(int star)
    {
        _starsImg.sprite = _spriteImg[star];
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayLevel5()
    {
        SceneManager.LoadScene(6);
    }

}
