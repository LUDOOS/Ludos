using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    bool ended = false;
    public int nextSceneNumber;
    MainPageSceneManager sceneManager;
    [SerializeField] private VideoPlayer StoryVideo ;
     void Start()
    {
        StoryVideo.loopPointReached += EndReached;
        sceneManager = GameObject.Find("SceneController").GetComponent<MainPageSceneManager>();
    }
    private void Update()
    {
        if (ended) {
            loadStory();
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        ended = true;
    }

    public void loadStory() {
        // if (nextSceneName.Equals("Seasons-lv1"))
        // {
        //     if (GameManager.instance.CalendarCurrentLevel >= 4)
        //         sceneManager.LoadDays(nextSceneName);
        //     else {
        //         sceneManager.GoToMainPage();
        //     }
        // }
        // else {
        //     sceneManager.changeScene(nextSceneName);
        // }
        if (SceneManager.GetActiveScene().name.Equals("Date-Story"))
        {
            sceneManager.LoadDaysStory(nextSceneNumber);
        }
        else sceneManager.LoadDays(nextSceneNumber);
    }

}
