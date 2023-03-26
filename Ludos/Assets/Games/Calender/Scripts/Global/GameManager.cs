using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
   // public bool isCompleted = false;

    public int CurrentLevel = 0; // -------------->>> LevelProgress
    public int nextLevel = 1; // -------------->>> LevelProgress

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

