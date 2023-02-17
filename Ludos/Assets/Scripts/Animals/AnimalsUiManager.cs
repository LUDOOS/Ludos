using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalsUiManager : MonoBehaviour
{
    [SerializeField] Sprite[] _spriteImg;
    [SerializeField] Image _starsImg;
    [SerializeField] public Image congrates;
    // Start is called before the first frame update
    private void Start()
    {
        congrates.gameObject.SetActive(false);
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
