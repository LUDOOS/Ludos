using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPageSceneManager : MonoBehaviour
{
   
    public void GoToMainPage () => SceneManager.LoadScene("Calendar-HomePage");
    
    public void GoToGamesPage () => SceneManager.LoadScene("GamesPage");
        
    public void LoadDays(int level)
    {
        switch (level)
        {
            case 1:
                GameManager.instance.CalendarCurrentLevel = 0; // -------------->>> LevelProgress
                SceneManager.LoadScene("Date-days-lv1");
                break;
            case 2:
                GameManager.instance.CalendarCurrentLevel = 1; // -------------->>> LevelProgress
                SceneManager.LoadScene("Date-days-lv2");
                break;
            case 3:
                GameManager.instance.CalendarCurrentLevel = 2; // -------------->>> LevelProgress
                SceneManager.LoadScene("Date-months-lv1");
                break;
            case 4:
                GameManager.instance.CalendarCurrentLevel = 3; // -------------->>> LevelProgress
                SceneManager.LoadScene("Date-months-lv2");
                break;
        }
    }

    public void LoadDaysStory(int level)
    {
        switch (level)
        {
            case 0:
                SceneManager.LoadScene("Date-Story");
                break;
            case 1:
                SceneManager.LoadScene("Date-Story 1");
                break;
            case 2:
                SceneManager.LoadScene("Date-Story 2");
                break;
            case 3:
                SceneManager.LoadScene("Date-Story 3");
                break;
            case 4:
                SceneManager.LoadScene("Date-Story 4");
                break;
            case 5:
                SceneManager.LoadScene("Date-Story 5");
                break;
        }
    }

    public void LoadSeasons(int level)
    {
        switch (level)
        {
            case 1:
                GameManager.instance.CalendarCurrentLevel = 4; // -------------->>> LevelProgress
                SceneManager.LoadScene("Seasons-lv1");
                break;
            case 2:
                GameManager.instance.CalendarCurrentLevel = 5; // -------------->>> LevelProgress
                SceneManager.LoadScene("Seasons-lv2");
                break;
            case 3:
                GameManager.instance.CalendarCurrentLevel = 6; // -------------->>> LevelProgress
                SceneManager.LoadScene("Seasons-lv3");
                break;
            case 4:
                GameManager.instance.CalendarCurrentLevel = 7; // -------------->>> LevelProgress
                SceneManager.LoadScene("Seasons-lv4");
                break;
        }
    }
    

    

}
    



