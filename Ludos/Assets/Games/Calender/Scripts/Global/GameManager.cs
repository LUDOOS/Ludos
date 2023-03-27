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

    public int MathTowerCurrentLevel = 0; // -------------->>> LevelProgress
    public int MathTowerNextLevel = 1; // -------------->>> LevelProgress
    public int MathTowerStars = 0;

    public int AnimalsCurrentLevel = 0; // -------------->>> LevelProgress
    public int AnimalsNextLevel = 1; // -------------->>> LevelProgress
    public int AnimalsStars = 0;

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

