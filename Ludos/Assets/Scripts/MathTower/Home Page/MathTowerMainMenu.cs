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
    int index = 2;

    private void Update()
    {
        UpdateIndicator();
        UnlockLevel();
    }

    private void LateUpdate()
    {
        
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
            index++;
            MathTowerGameManager.instance.isCompleted = false;
            Debug.Log(MathTowerGameManager.instance.level + 1);
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
