using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moveTo(string game) {
        //time_game is at x = -18.72 y = 0
        //date_game is at x = 15.802 y = 0
        //seasons_game is at x = 0 y = -10.06
        switch (game) {
            case "seasons":
                Debug.Log("seasssss");
                break;
            case "date":
                Debug.Log("dateeee");
                break;
            case "time":
                Debug.Log("ttttttt");
                break;
            default:
                Debug.Log(game);
                break;
        }
    }
    public void moveToDates() { }
    public void moveToSeasons() { }
    public void moveToTime() { }
    public void moveToMainPage() { }

}
