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
        CalendarCurrentLevel = AuthManger.Instance.children.TimeAndDate.Count - 1;
        CalendarNextLevel = AuthManger.Instance.children.TimeAndDate.Count;
        CalendarStars = 0;

        mathTowerCurrentLevel = AuthManger.Instance.children.Math.Count - 1;
        mathTowerNextLevel = AuthManger.Instance.children.Math.Count;
        mathTowerStars = 0;

        animalsCurrentLevel = AuthManger.Instance.children.Animals.Count - 1;
        animalsNextLevel = AuthManger.Instance.children.Animals.Count; 
        animalsStars = 0;

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
}