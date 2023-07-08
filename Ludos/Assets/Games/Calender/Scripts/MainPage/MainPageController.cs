using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPageController : MonoBehaviour
{
    CameraLerp mainCam;
    Transform Avatar;
    AnimationController animationController;
    [SerializeField] Slider [] slider;
   
    public Button[] LevelButtons; // -------------->>> LevelProgress

    Vector3[,] page_avatarPositions = new[,] {
        { new Vector3(0, -0.12f, -10), new Vector3(0f, 2.4f) } ,  //Main Page pos
        { new Vector3(11.85f, 0, -10),new Vector3(10.6f,2.67f)}, //Date Page Pos
        { new Vector3(0, -10.06f, -10), new Vector3(-1.27f,-7)} //Seasons Page Pos
    };


    // Start is called before the first frame update
    private void Start()
    {
        mainCam = GameObject.Find("MainCamParent").GetComponent<CameraLerp>();
        animationController = GameObject.Find("AnimationController").GetComponent<AnimationController>();
        Avatar = GameObject.FindGameObjectWithTag("avatar").transform;
        updateLevels(); // -------------->>> LevelProgress
        StartCoroutine(animationController.destroyAnimation("LevelLoader", 2.85f));


    }
    private void Update()
    {
        
        
    }

    public void moveToCalender()
    {
        animationController.animate("UI1_enable", "Canvas");
        StartCoroutine(mainCam.LerpFromTo( page_avatarPositions[1, 0], 1f, 0.4f));
        StartCoroutine(LerpFromTo(Avatar.position, page_avatarPositions[1, 1], 1.05f, Avatar,0.3f));
    }
    public void moveToSeasons() {
        animationController.animate("UI2_enable", "Canvas");
        StartCoroutine(mainCam.LerpFromTo( page_avatarPositions[2, 0], 1.3f, 0.4f));
        StartCoroutine(LerpFromTo(Avatar.position, page_avatarPositions[2, 1], 1.05f, Avatar,0.3f));
    }
    public void moveToMainPage() {
        StartCoroutine(mainCam.LerpFromTo(page_avatarPositions[0, 0], 1f, 0f));
        StartCoroutine(LerpFromTo(Avatar.position, page_avatarPositions[0, 1], 1.05f, Avatar,0));
    }

    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration , Transform gameObject , float delay )
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(pos2 + gameObject.name );
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            gameObject.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        gameObject.position = pos2;
    }



    void updateLevels() // -------------->>> LevelProgress
    {
        Debug.Log("updating");
        for (int i = 0; i < GameManager.instance.CalendarNextLevel; i++)
        {
           LevelButtons[i].interactable = true;
           
        }
        if (GameManager.instance.CalendarNextLevel < 4)
        {
            slider[0].value = GameManager.instance.CalendarNextLevel - 1 ;
        }
        else
        {
            slider[0].value = 5;
            slider[1].value = GameManager.instance.CalendarNextLevel - 4;
        }
    }


}



