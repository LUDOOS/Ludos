using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPageSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string game)
    {


        switch (game)
        {
            case "time-lv1":
                SceneManager.LoadScene("Time-lv1");
                break;
            case "time-lv2":
                SceneManager.LoadScene("Time-lv2");
                break;
            case "time-Story":
                SceneManager.LoadScene("Time-Story");
                break;




            case "days-lv1":
                SceneManager.LoadScene("Date-days-lv1");
                break;
            case "days-lv2":
                SceneManager.LoadScene("Date-days-lv2");
                break;
            case "months-lv1":
                SceneManager.LoadScene("Date-months-lv1");
                break;
            case "months-lv2":
                SceneManager.LoadScene("Date-months-lv2");
                break;
            case "date-Story":
                SceneManager.LoadScene("Date-Story");
                break;



            case "Seasons-lv1":
                SceneManager.LoadScene("Seasons-lv1");
                break;
            case "Seasons-lv2":
                SceneManager.LoadScene("Seasons-lv2");
                break;
            case "Seasons-Story":
                SceneManager.LoadScene("Seasons-Story");
                break;

            case "MainPage":
                SceneManager.LoadScene("HomePage");
               
                break;

            default:
                Debug.Log("xd");
                break;
        }

    }
}
    



