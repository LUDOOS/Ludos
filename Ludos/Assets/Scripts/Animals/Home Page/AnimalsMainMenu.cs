using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsMainMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(7);
    }
    public void PlayStory()
    {
        SceneManager.LoadScene(13);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(8);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(9);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(10);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(11);
    }

    public void PlayLevel5()
    {
        SceneManager.LoadScene(12);
    }
}
