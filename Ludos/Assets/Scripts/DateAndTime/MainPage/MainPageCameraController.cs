using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageCameraController : MonoBehaviour
{
    Transform mainCam;
    Transform Avatar;
    
    bool clicked = false;
    string target = "";

    Vector3 [] pageLocations = new[] {
        new Vector3(0, 0, -10),  //Main Page pos
        new Vector3(-12.56f, 0, -10), //Time Page Pos
        new Vector3(11.85f, 0, -10), //Date Page Pos
        new Vector3(0, -10.06f, -10) //Seasons Page Pos
    };
    Vector3[] avatarLocations = new[] {
        new Vector3(-1.27f, 2.67f), //Main Page pos
        new Vector3(-13.7f,2.67f), //Time Page Pos
        new Vector3(10.6f,2.67f), //Date Page Pos
        new Vector3(-1.27f,-7) //Seasons Page Pos
    };
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Avatar = GameObject.FindGameObjectWithTag("avatar").transform;
        Application.targetFrameRate = 60;

    }

// Update is called once per frame
void Update()
    {
        if (clicked && target != "") {
            moveTo(target);
        }
       
    }
    public void clickHandler(string target) {
        clicked = true;
        this.target = target;
    }
    public void moveTo(string game)
    {

        //time_game is at x = -18.72 y = 0
        //date_game is at x = 15.802 y = 0
        //seasons_game is at x = 0 y = -10.06

        switch (game)
        {     
            default:
                Debug.Log("def");
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[0], 1f, mainCam));
                StartCoroutine(LerpFromTo(Avatar.position, avatarLocations[0], 1.05f, Avatar));
                clicked = false;
                target = "";
                break;
            case "time":
                Debug.Log("ttttttt");
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[1], 0.8f, mainCam));
                StartCoroutine(LerpFromTo(Avatar.position, avatarLocations[1], 0.856f, Avatar));
                clicked = false;
                target = "";
                break;
            case "date":
                Debug.Log("dateeee");
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[2], 1f, mainCam));
                StartCoroutine(LerpFromTo(Avatar.position, avatarLocations[2], 1.05f, Avatar));
                clicked = false;
                target = "";
                break;
            case "seasons":
                Debug.Log(mainCam.position);
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[3], 1.3f,mainCam));
                StartCoroutine(LerpFromTo(Avatar.position, avatarLocations[3], 1.5f, Avatar));
                clicked = false;
                target = "";
                break;            

 


        }
    }
    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration , Transform test )
    {
        Debug.Log(pos2 + test.name );
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            test.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        test.position = pos2;
    }


}
