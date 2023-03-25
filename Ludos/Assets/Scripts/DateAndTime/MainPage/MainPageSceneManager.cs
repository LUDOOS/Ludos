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
            case "date-Story1":
                SceneManager.LoadScene("Date-Story 1");
                break;
            case "date-Story2":
                SceneManager.LoadScene("Date-Story 2");
                break;
            case "date-Story3":
                SceneManager.LoadScene("Date-Story 3");
                break;
            case "date-Story4":
                SceneManager.LoadScene("Date-Story 4");
                break;

            case "date-Story5":
                SceneManager.LoadScene("Date-Story 5");
                break;



            case "Seasons-lv1":
                SceneManager.LoadScene("Seasons-lv1");
                break;
            case "Seasons-lv2":
                SceneManager.LoadScene("Seasons-lv2");
                break;
            case "Seasons-lv3":
                SceneManager.LoadScene("Seasons-lv3");
                break;
            case "Seasons-lv4":
                SceneManager.LoadScene("Seasons-lv4");
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
    



