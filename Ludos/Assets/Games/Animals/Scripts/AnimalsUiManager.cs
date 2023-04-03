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
    [SerializeField] public RawImage confetti;
    //[SerializeField] Timer _timer;
    public int time = 180;
    int stars = 0;
    // Start is called before the first frame update
    private void Start()
    {
        congrates.gameObject.SetActive(false);
        confetti.enabled = false;
    }
    public void UpdateStars(int second)
    {
        if (second >= 30)
        {
            _starsImg.sprite = _spriteImg[3];
            stars = 3;
        }
        else if (second >= 15)
        {
            _starsImg.sprite = _spriteImg[2];
            stars = 2;
        }
        else
        {
            _starsImg.sprite = _spriteImg[1];
            stars = 1;
        }
        //Stars.instance.ObserveOnStarsChanged(game: AuthManger.Instance.children.Animals, currentStars: stars);
    }

    public void StopTimer()
    {
        Timer.SetPaused(false);
    }
}
