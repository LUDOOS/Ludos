using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathTowerMainMenu : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image Locked2;
    [SerializeField] Image Locked3;
    [SerializeField] Image Locked4;
    [SerializeField] Image Locked5;

    private void Update()
    {
        UpdateIndicator();
        UnlockLevel();
    }

    void UnlockLevel()
    {
        if (MathTowerGameManager.instance.isCompleted)
        {
            switch (MathTowerGameManager.instance.level+1)
            {
                case 2:
                    Locked2.enabled = false;      
                    break;
                case 3:
                    Locked2.enabled = false;
                    Locked3.enabled = false; 
                    break;
                case 4:
                    Locked2.enabled = false;
                    Locked3.enabled = false;
                    Locked4.enabled = false;
                    break;
                case 5:
                    Locked2.enabled = false;
                    Locked3.enabled = false;
                    Locked4.enabled = false;
                    Locked5.enabled = false;
                    break;
                default:
                    Debug.Log("Default");
                    break;
            }
            MathTowerGameManager.instance.isCompleted = false;
        }
    }

    void UpdateIndicator()
    {
        if (MathTowerGameManager.instance.isCompleted)
        {
            slider.value = MathTowerGameManager.instance.level;
        }
    }
}
