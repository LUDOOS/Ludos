using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
   // public bool isCompleted = false;

    public int CalendarCurrentLevel = 0; // -------------->>> LevelProgress
    public int CalendarNextLevel = 1; // -------------->>> LevelProgress
    public int CalendarStars = 0;

    public int mathTowerCurrentLevel = 0; // -------------->>> LevelProgress
    public int mathTowerNextLevel = 1; // -------------->>> LevelProgress
    public int mathTowerStars = 0;

    public int animalsCurrentLevel = 0; // -------------->>> LevelProgress
    public int animalsNextLevel = 1; // -------------->>> LevelProgress
    public int animalsStars = 0;

    private void Start()
    {
        
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

