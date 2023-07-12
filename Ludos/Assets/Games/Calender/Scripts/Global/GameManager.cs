using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public VideoPlayer achievementVideoPlayer;
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

    public bool achievementIsPlaying = false;

    // private GameObject congrats;
    private GameObject confetti;
    //private int totalStars;

    private void Start()
    {
        CalendarNextLevel = AuthManger.Instance.children.Calendar.Count + 1 ;
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
           StartCoroutine(UnlockAchievement(0));
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
                    }
                    else if (System.Convert.ToInt32(AuthManger.Instance.children.Math[level]) < stars)
                    {
                        int temp = stars - System.Convert.ToInt32(AuthManger.Instance.children.Math[level]);
                        AuthManger.Instance.children.Total_stars += temp;
                        AuthManger.Instance.children.achievedStars += temp;
                        AuthManger.Instance.children.Math[level] = stars;
                    }
                    CheckAndUnlockAchievement(GameName,1,15);
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
                    CheckAndUnlockAchievement(GameName,3,15);
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
                    CheckAndUnlockAchievement(GameName,2,24);
             
                    break;
                default:
                    Debug.LogError("Game Manager class :: UpdateData GameName does not match");
                    break;
            }
        }
        
        if(AuthManger.Instance.children.FinishedAllGames())
        {
            Debug.Log(AuthManger.Instance.children.FinishedAllGames());
            StartCoroutine(UnlockAchievement(4));
        }
        
    }


    
    private void CheckAndUnlockAchievement(string gameName ,int achievementIndex , int tStars)
    {
        if (AuthManger.Instance.children.getTotalStars(gameName) == tStars && !AuthManger.Instance.children.CheckUnlocked(achievementIndex))
        {
            StartCoroutine(UnlockAchievement(achievementIndex));
        }
    }
    private IEnumerator UnlockAchievement(int achievementIndex)
    {
        
        
        while (achievementIsPlaying) yield return null;
        enableConfetti(false);
        achievementIsPlaying = true;
        AuthManger.Instance.children.Achievements[achievementIndex] = true;
        achievementVideoPlayer.clip = Resources.Load<VideoClip>($"achievementVideos/{achievementIndex}");
        achievementVideoPlayer.transform.parent.gameObject.SetActive(true);
        achievementVideoPlayer.loopPointReached += EndReached;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        achievementVideoPlayer.transform.parent.gameObject.SetActive(false);
        achievementIsPlaying = false;
        enableConfetti(true);
    }

    private void enableConfetti(bool state)
    {
        //congrats = GameObject.Find("Congrats");
        confetti = GameObject.Find("Confetti");
        Debug.Log(state);
        if (confetti != null) confetti.GetComponent<VideoPlayer>().enabled = state;
        //if (congrats != null) congrats.SetActive(state);
    }
}