using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] public Button textBackground;
    [SerializeField] Text _question;
    [SerializeField] Sprite[] _spriteImg;
    [SerializeField] Image _starsImg;
    [SerializeField] public Image congrates;
    string[] _questionText = {"1 + 1", "2 + 3", "7 + 1"};
    // Start is called before the first frame update
    void Start()
    {
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
}
