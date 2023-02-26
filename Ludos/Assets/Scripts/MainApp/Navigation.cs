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
    public void Navigate(int index)
    {
        StartCoroutine(loadScene(index));
    }

    public void NavToGamePage()
    {
        StartCoroutine(loadScene(1));
    }

    public void NavToSettingsPage()
    {
        SceneManager.LoadScene(2);
    }

    public void NavToAchivments()
    {
        SceneManager.LoadScene(3);
    }

    public void NavToShop()
    {
        SceneManager.LoadScene(4);
    }
    /// </MainPages>

    ///<Games>

    //public void NavToMathTower()
    //{
    //    SceneManager.LoadScene(0);
    //}

    public void NavToAnimals()
    {
        SceneManager.LoadScene(5);
    }

    //public void NavToDatesAndTime()
    //{
    //    //SceneManager.LoadScene(0);
    //}

    ///</Games>
    ///

    // <Animals Levels>

    public void AnimalsStory()
    {
        SceneManager.LoadScene(6);
    }

    public void AnimalsLevel1()
    {
        SceneManager.LoadScene(7);
    }

    public void AnimalsLevel2()
    {
        SceneManager.LoadScene(8);
    }

    public void AnimalsLevel3()
    {
        SceneManager.LoadScene(9);
    }

    public void AnimalsLevel4()
    {
        SceneManager.LoadScene(10);
    }

    public void AnimalsLevel5()
    {
        SceneManager.LoadScene(11);
    }

    // </Animals Levels>


}
