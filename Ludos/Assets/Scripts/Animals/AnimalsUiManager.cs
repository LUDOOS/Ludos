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
    // Start is called before the first frame update
    private void Start()
    {
        congrates.gameObject.SetActive(false);
        confetti.enabled = false;
    }
    public void updateStars(int star)
    {
        _starsImg.sprite = _spriteImg[star];
    }
}
