using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathTowerMainMenu : MonoBehaviour
{
    [SerializeField] Slider slider;

    private void Update()
    {
        UpdateIndicator();
    }

    void UpdateIndicator()
    {
        if (MathTowerGameManager.instance.isCompleted)
        {
            slider.value = MathTowerGameManager.instance.level;
        }
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayLevel5()
    {
        SceneManager.LoadScene(5);
    }
}
