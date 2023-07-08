using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalPageController : MonoBehaviour
{
    public Button[] LevelButtons;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevels();
    }

    void UpdateLevels()
    {
        for (int i = 0; i < GameManager.instance.animalsNextLevel; i++)
        {
            LevelButtons[i].interactable = true;
        }
        slider.value = GameManager.instance.animalsNextLevel;
    }
}

