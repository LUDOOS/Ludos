using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    public Animator animator;
    
    IEnumerator loadScene(string index)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(index);
    }

    /// <MainPages>


    public void NavToGamePage()
    {
        StartCoroutine(loadScene("GamesPage"));
    }

    public void NavToSettingsPage()
    {
        SceneManager.LoadScene("SettingsPage");
    }

    public void NavToAchivments()
    {
        SceneManager.LoadScene("AchivementPage");
    }

    public void NavToShop()
    {
        SceneManager.LoadScene("ShopPage");
    }

    public void NavToHome() {
        SceneManager.LoadScene("HomePage");
    }
    /// </MainPages>

    ///<Games>

    public void NavToMathTower()
    {
        SceneManager.LoadScene("Math-HomePage");
    }

    public void NavToAnimals()
    {
        SceneManager.LoadScene("Animals-HomePage");
    }
    public void NavToCalender()
    {
        SceneManager.LoadScene("Calendar-HomePage");
    }
    public void LogOut() {
        AuthManger.Instance.LogOut();
    }


    ///</Games>
    ///

    // <Animals Levels>
    public void AnimalsStory()
    {
        SceneManager.LoadScene("Animals-Story");
        //GameManager.instance.animalsCurrentLevel = 0;
    }

    public void AnimalsLevel1()
    {
        SceneManager.LoadScene("Animals-Level-1");
        GameManager.instance.animalsCurrentLevel = 0;
    }

    public void AnimalsLevel2()
    {
        SceneManager.LoadScene("Animals-Level-2");
        GameManager.instance.animalsCurrentLevel = 1;
    }

    public void AnimalsLevel3()
    {
        SceneManager.LoadScene("Animals-Level-3");
        GameManager.instance.animalsCurrentLevel = 2;
    }

    public void AnimalsLevel4()
    {
        SceneManager.LoadScene("Animals-Level-4");
        GameManager.instance.animalsCurrentLevel = 3;
    }

    public void AnimalsLevel5()
    {
        SceneManager.LoadScene("Animals-Level-5");
        GameManager.instance.animalsCurrentLevel = 4;
    }
    // </Animals Levels>


    // <Math Tower Levels>

  

    public void MathTowerLevel1()
    {
        SceneManager.LoadScene("Math-Level-1");
        GameManager.instance.mathTowerCurrentLevel = 0;
    }

    public void MathTowerLevel2()
    {
        SceneManager.LoadScene("Math-Level-2");
        GameManager.instance.mathTowerCurrentLevel = 1;
    }

    public void MathTowerLevel3()
    {
        SceneManager.LoadScene("Math-Level-3");
        GameManager.instance.mathTowerCurrentLevel = 2;
    }

    public void MathTowerLevel4()
    {
        SceneManager.LoadScene("Math-Level-4");
        GameManager.instance.mathTowerCurrentLevel = 3;
    }

    public void MathTowerLevel5()
    {
        SceneManager.LoadScene("Math-Level-5");
        GameManager.instance.mathTowerCurrentLevel = 4;
    }


    // </Math Tower Levels>
}
