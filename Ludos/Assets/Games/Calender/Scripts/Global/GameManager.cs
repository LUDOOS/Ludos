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

    private void Start()
    {
        CalendarCurrentLevel = AuthManger.Instance.children.Calendar.Count - 1;
        CalendarNextLevel = AuthManger.Instance.children.Calendar.Count;
        CalendarStars = 0;

        mathTowerCurrentLevel = AuthManger.Instance.children.Math.Count - 1;
        mathTowerNextLevel = AuthManger.Instance.children.Math.Count;
        mathTowerStars = 0;

        animalsCurrentLevel = AuthManger.Instance.children.Animals.Count - 1;
        animalsNextLevel = AuthManger.Instance.children.Animals.Count;
        animalsStars = 0;
        AuthManger.Instance.children.getTotalstars(AuthManger.Instance.children.Animals);

        Debug.Log("Game Manager class :: Math Current Level = " + $"{AuthManger.Instance.children.Math.Count - 1}");
        Debug.Log("Game Manager class :: Math Next Level = " + $"{AuthManger.Instance.children.Math.Count}");
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
                if (AuthManger.Instance.children.Math.Count-1 < level) {
                    AuthManger.Instance.children.Math.Add(stars);
                    mathTowerNextLevel++;
                    mathTowerCurrentLevel++;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                else if (System.Convert.ToInt32(AuthManger.Instance.children.Math[level]) < stars)
                {
                    Debug.Log(System.Convert.ToInt32(AuthManger.Instance.children.Math[level]));
                    AuthManger.Instance.children.Math[level] = stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                break;
            case "animals":
            case "Animals":
                if (AuthManger.Instance.children.Animals.Count - 1 < level)
                {
                    AuthManger.Instance.children.Animals.Add(stars);
                    animalsNextLevel++;
                    animalsCurrentLevel++;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                else if (System.Convert.ToInt32(AuthManger.Instance.children.Animals[level])< stars)
                {
                    AuthManger.Instance.children.Animals[level] = stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                break;
            case "calendar":
            case "Calendar":
                if (AuthManger.Instance.children.Calendar.Count - 1 < level)
                {
                    CalendarNextLevel++;
                    CalendarCurrentLevel++;
                    AuthManger.Instance.children.Calendar.Add(stars);
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                if (System.Convert.ToInt32(AuthManger.Instance.children.Calendar[level] )< stars)
                {
                    AuthManger.Instance.children.Calendar[level] = stars;
                    AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                }
                break;
            default:
                Debug.LogError("Game Manager class :: UpdateData GameName not match");
                break;
        }
    }
}