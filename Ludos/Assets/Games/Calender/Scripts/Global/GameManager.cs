using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // todo: calculate starts for each game

    public int CalendarCurrentLevel; // -------------->>> LevelProgress
    public int CalendarNextLevel; // -------------->>> LevelProgress
    public int CalendarStars;

    public int mathTowerCurrentLevel; // -------------->>> LevelProgress
    public int mathTowerNextLevel; // -------------->>> LevelProgress
    public int mathTowerStars;

    public int animalsCurrentLevel; // -------------->>> LevelProgress
    public int animalsNextLevel; // -------------->>> LevelProgress
    public int animalsStars;

    //private int totalStars;

    private void Start()
    {
        CalendarNextLevel = AuthManger.Instance.children.Calendar.Count + 1;
        CalendarStars = 0;

        mathTowerNextLevel = AuthManger.Instance.children.Math.Count + 1;
        mathTowerStars = 0;

        animalsNextLevel = AuthManger.Instance.children.Animals.Count + 1;
        animalsStars = 0;

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateData(string GameName, int level, int stars)
    {
        if (AuthManger.Instance.children.isFirstGame())
        {
            // unlock first achievement
        }

        if (stars <= 3)
        {
            switch (GameName.ToLower())
            {
                case "math":
                    if (AuthManger.Instance.children.Math.Count == level)
                    {
                        AuthManger.Instance.children.Math.Add(stars);
                        mathTowerNextLevel++;
                        AuthManger.Instance.children.Total_stars += stars;
                        AuthManger.Instance.children.achievedStars += stars;
                        AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                    }
                    else if (System.Convert.ToInt32(AuthManger.Instance.children.Math[level]) < stars)
                    {
                        int temp = stars - System.Convert.ToInt32(AuthManger.Instance.children.Math[level]);
                        AuthManger.Instance.children.Total_stars += temp;
                        AuthManger.Instance.children.achievedStars += temp;
                        AuthManger.Instance.children.Math[level] = stars;
                        AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                    }
                    CheckAndUnlockAchievement(GameName);
                    break;
                case "animals":
                    if (AuthManger.Instance.children.Animals.Count == level)
                    {
                        AuthManger.Instance.children.Animals.Add(stars);
                        animalsNextLevel++;
                        AuthManger.Instance.children.Total_stars += stars;
                        AuthManger.Instance.children.achievedStars += stars;
                    }
                    else if (System.Convert.ToInt32(AuthManger.Instance.children.Animals[level]) < stars)
                    {
                        int temp = stars - System.Convert.ToInt32(AuthManger.Instance.children.Animals[level]);
                        AuthManger.Instance.children.Total_stars += temp;
                        AuthManger.Instance.children.achievedStars += temp;
                        AuthManger.Instance.children.Animals[level] = stars;
                    }
                    CheckAndUnlockAchievement(GameName);
                    break;
                case "calendar":
                    if (AuthManger.Instance.children.Calendar.Count == level)
                    {
                        CalendarNextLevel++;
                        AuthManger.Instance.children.Total_stars += stars;
                        AuthManger.Instance.children.achievedStars += stars;
                        AuthManger.Instance.children.Calendar.Add(stars);
                    }
                    else if (System.Convert.ToInt32(AuthManger.Instance.children.Calendar[level]) < stars)
                    {
                        int temp = stars - System.Convert.ToInt32(AuthManger.Instance.children.Calendar[level]);
                        AuthManger.Instance.children.Total_stars += temp;
                        AuthManger.Instance.children.achievedStars += temp;
                        AuthManger.Instance.children.Calendar[level] = stars;
                    }
                    CheckAndUnlockAchievement(GameName,24);
                    break;
                default:
                    Debug.LogError("Game Manager class :: UpdateData GameName does not match");
                    break;
            }
        }

        else
        {
            //TODO delete account if someone hacked the game
        }
    }

    private void CheckAndUnlockAchievement(string gameName)
    {
        if (AuthManger.Instance.children.getTotalStars(gameName) == 15)
        {
            //TODO give math achievement 
            //TODO check for duplicate unlock
        }
    }
    
    private void CheckAndUnlockAchievement(string gameName , int tStars)
    {
        if (AuthManger.Instance.children.getTotalStars(gameName) == tStars)
        {
            //TODO give math achievement 
            //TODO check for duplicate unlock
        }
    }
}