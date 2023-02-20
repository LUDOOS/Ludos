using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    /// <MainPages>
    public void NavToHomePage()
    {
        SceneManager.LoadScene(15);
    }

    public void NavToGamePage()
    {
        SceneManager.LoadScene(14);
    }

    public void NavToSettingsPage()
    {
        SceneManager.LoadScene(15);
    }

    public void NavToAchivments()
    {
        //SceneManager.LoadScene();
    }

    public void NavToCreaditis()
    {
        //SceneManager.LoadScene();
    }
    /// </MainPages>

    ///<Games>

    public void NavToMathTower()
    {
        SceneManager.LoadScene(0);
    }

    public void NavToAnimals()
    {
        SceneManager.LoadScene(7);
    }

    public void NavToDatesAndTime()
    {
        //SceneManager.LoadScene(0);
    }

    ///</Games>


}
