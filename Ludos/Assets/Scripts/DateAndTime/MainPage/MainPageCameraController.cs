using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageCameraController : MonoBehaviour
{
    CameraLerp mainCam;
    Transform Avatar;
    AnimationController animationController;

    Vector3[,] page_avatarPositions = new[,] {
        { new Vector3(0, -0.12f, -10), new Vector3(0f, 2.4f) } ,  //Main Page pos
        { new Vector3(11.85f, 0, -10),new Vector3(10.6f,2.67f)}, //Date Page Pos
        { new Vector3(0, -10.06f, -10), new Vector3(-1.27f,-7)} //Seasons Page Pos
    };


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("MainCamParent").GetComponent<CameraLerp>();
        animationController = GameObject.Find("AnimationController").GetComponent<AnimationController>();
        Avatar = GameObject.FindGameObjectWithTag("avatar").transform;
        Application.targetFrameRate = 60;

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


}
