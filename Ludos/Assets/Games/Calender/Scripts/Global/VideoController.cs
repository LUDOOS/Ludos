using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    bool ended = false;
    public string nextSceneName;
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
        if (nextSceneName.Equals("Seasons-lv1"))
        {
            if (GameManager.instance.CalendarCurrentLevel >= 4)
                sceneManager.changeScene(nextSceneName);
            else {
                sceneManager.changeScene("MainPage");
            }
        }
        else {
            sceneManager.changeScene(nextSceneName);
        }
    }

}
