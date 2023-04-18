using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // todo: calculate starts for each game

    public int CalendarCurrentLevel; // -------------->>> LevelProgress
    public int CalendarNextLevel;   // -------------->>> LevelProgress
    public int CalendarStars;

    public int mathTowerCurrentLevel; // -------------->>> LevelProgress
    public int mathTowerNextLevel;     // -------------->>> LevelProgress
    public int mathTowerStars;

    public int animalsCurrentLevel; // -------------->>> LevelProgress
    public int animalsNextLevel; // -------------->>> LevelProgress
    public int animalsStars;

    //private int totalStars;

    private void Start()
    {
        //CalendarCurrentLevel = AuthManger.Instance.children.Calendar.Count;
        CalendarNextLevel = AuthManger.Instance.children.Calendar.Count + 1 ;
        CalendarStars = 0;

        mathTowerCurrentLevel = AuthManger.Instance.children.Math.Count ;
        mathTowerNextLevel = AuthManger.Instance.children.Math.Count + 1;
        mathTowerStars = 0;

        animalsCurrentLevel = AuthManger.Instance.children.Animals.Count;
        animalsNextLevel = AuthManger.Instance.children.Animals.Count + 1;
        animalsStars = 0;
        //under test
        //AuthManger.Instance.children.getTotalstars(AuthManger.Instance.children.Animals);
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
        switch (GameName)
        {
            case "math":
            case "Math":
                if (AuthManger.Instance.children.Math.Count == level) {
                    AuthManger.Instance.children.Math.Add(stars);
                    mathTowerNextLevel++;
                    //mathTowerCurrentLevel++;
                    AuthManger.Instance.children.Total_stars += stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                else if (System.Convert.ToInt32(AuthManger.Instance.children.Math[level]) < stars)
                {
                    //Debug.Log(System.Convert.ToInt32(AuthManger.Instance.children.Math[level]));
                    int temp =stars - System.Convert.ToInt32(AuthManger.Instance.children.Math[level]);
                    AuthManger.Instance.children.Total_stars += temp;
                    AuthManger.Instance.children.Math[level] = stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                break;
            case "animals":
            case "Animals":
                if (AuthManger.Instance.children.Animals.Count == level)
                {
                    AuthManger.Instance.children.Animals.Add(stars);
                    animalsNextLevel++;
                    //animalsCurrentLevel++;
                    AuthManger.Instance.children.Total_stars += stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                else if (System.Convert.ToInt32(AuthManger.Instance.children.Animals[level])< stars)
                {
                    int temp = stars - System.Convert.ToInt32(AuthManger.Instance.children.Animals[level]);
                    AuthManger.Instance.children.Total_stars += temp;
                    AuthManger.Instance.children.Animals[level] = stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                break;
            case "calendar":
            case "Calendar":
                if (AuthManger.Instance.children.Calendar.Count == level)
                {
                    CalendarNextLevel++;
                    AuthManger.Instance.children.Total_stars += stars;
                    AuthManger.Instance.children.Calendar.Add(stars);
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                else if (System.Convert.ToInt32(AuthManger.Instance.children.Calendar[level] )< stars)
                {
                    int temp = stars - System.Convert.ToInt32(AuthManger.Instance.children.Calendar[level]);
                    AuthManger.Instance.children.Total_stars += temp;
                    AuthManger.Instance.children.Calendar[level] = stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                break;
            default:
                Debug.LogError("Game Manager class :: UpdateData GameName does not match");
                break;
        }
    }
}