using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsIndicator : MonoBehaviour
{
    [SerializeField] private Image uiFillImage;

    public  void UpdateUI(float progress)
    {
        Debug.Log(progress);
        uiFillImage.fillAmount = progress;
    }
}
