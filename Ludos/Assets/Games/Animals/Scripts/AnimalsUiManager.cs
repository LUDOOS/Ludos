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
    // Start is called before the first frame update
    private void Start()
    {
        congrates.gameObject.SetActive(false);
        confetti.enabled = false;
    }
    public void UpdateStars(int second)
    {
        if (second >= 40)
        {
            _starsImg.sprite = _spriteImg[3];
            //Stars.instance.starsNumber += 3;
        }
        else if (second >= 20)
        {
            _starsImg.sprite = _spriteImg[2];
            //Stars.instance.starsNumber += 2;
        }
        else
        {
            _starsImg.sprite = _spriteImg[1];
            //Stars.instance.starsNumber += 1;
        }
    }

    public void StopTimer()
    {
        Timer.SetPaused(false);
    }
}
