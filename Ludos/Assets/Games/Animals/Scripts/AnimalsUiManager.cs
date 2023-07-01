using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalsUiManager : MonoBehaviour
{
    [SerializeField] Sprite[] _spriteImg;
    public Image starsImg;
    public Image congrats;
    [SerializeField] public RawImage confetti;
    //[SerializeField] Timer _timer;
    public int time = 180;
    // Start is called before the first frame update
    private void Start()
    {
        congrats.gameObject.SetActive(false);
        confetti.enabled = false;
    }

    public void UpdateStars(int stars)
    {
        if (stars  == 3)
        {
            starsImg.sprite = _spriteImg[3];
            //Stars.instance.starsNumber += 3;
        }
        else if (stars == 2)
        {
            starsImg.sprite = _spriteImg[2];
            //Stars.instance.starsNumber += 2;
        }
        else
        {
            starsImg.sprite = _spriteImg[1];
            //Stars.instance.starsNumber += 1;
        }
    }
    public void StopTimer()
    {
        Timer.SetPaused(false);
    }
}
