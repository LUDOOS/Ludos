using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public Animator animator;

    IEnumerator loadScene(int index)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(index);
    }

    /// <MainPages>
    public void NavToHomePage()
    {
        StartCoroutine(loadScene(15));
    }

    public void NavToGamePage()
    {
        StartCoroutine(loadScene(14));
    }

    //public void NavToSettingsPage()
    //{
    //    SceneManager.LoadScene(15);
    //}

    //public void NavToAchivments()
    //{
    //    //SceneManager.LoadScene();
    //}

    //public void NavToCreaditis()
    //{
    //    //SceneManager.LoadScene();
    //}
    /// </MainPages>

    ///<Games>

    //public void NavToMathTower()
    //{
    //    SceneManager.LoadScene(0);
    //}

    //public void NavToAnimals()
    //{
    //    SceneManager.LoadScene(7);
    //}

    //public void NavToDatesAndTime()
    //{
    //    //SceneManager.LoadScene(0);
    //}

    ///</Games>


}
