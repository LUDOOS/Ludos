using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public static Stars instance;
    public int stars = 0;
    public int earnedStars = 0;

    /// <summary>
    /// <param name="currentStars"/> 
    /// variable we have to create it in each game and reassign 
    /// it base on (time or right answers) how the game works generally
    /// at the end of the game we call the <see cref="ObserveOnStarsChanged(IList, int)"/> function
    /// <param name="game"/>
    /// this list comes from the firebase on class <see cref="Children"/>
    /// </summary>
    public void ObserveOnStarsChanged(IList game, int currentStars)
    {
        int totalLevels = game.Count;
        Debug.Log("ObserveOnStarsChanged() :: levels = " + $"{totalLevels}");
        if ( totalLevels > 1)
        {
            for (int i = 1; i < totalLevels; i++)
            {
                Debug.Log("Index = " + i);
                bool isNotNull = game[i] != null;
                // if the earnedStars user get this time more than last time
                if (currentStars > System.Convert.ToInt32(game[i]) && isNotNull)
                {
                    int diff = currentStars - System.Convert.ToInt32(game[i]);
                    this.earnedStars += diff;
                }
                // if he get less than the last time
                else if (currentStars < System.Convert.ToInt32(game[i]) && isNotNull)
                {
                    Debug.Log("ObserveOnStarsChanged() :: current earnedStars = " + $"{currentStars} " + "earnedStars from firbase = " + $"{game[i]}");
                    this.earnedStars = System.Convert.ToInt32(game[i]);
                }
                else
                {
                    Debug.Log("Stars Class :: The Player has : " + $"{this.earnedStars}" + " Stars");
                }
            }
        }
        else
        {
            if (currentStars > System.Convert.ToInt32(game[1]))
            {
                int diff = currentStars - System.Convert.ToInt32(game[1]);
                this.earnedStars += diff;
            }
            // if he get less than the last time
            else if (currentStars < System.Convert.ToInt32(game[1]))
            {
                Debug.Log("ObserveOnStarsChanged() :: current earnedStars = " + $"{currentStars} " + "earnedStars from firbase = " + $"{game[1]}");
                this.earnedStars = System.Convert.ToInt32(game[1]);
            }
            else
            {
                Debug.Log("Stars Class :: The Player has : " + $"{this.earnedStars}" + " Stars");
            }
        }
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
