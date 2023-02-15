using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsIndicator : MonoBehaviour
{
    [SerializeField] private Image uiFillImage;

    private void Start()
    {
        UpdateUI(0.5f);
    }

    public void UpdateUI(float progress)
    {
        uiFillImage.fillAmount = progress;
    }
}
