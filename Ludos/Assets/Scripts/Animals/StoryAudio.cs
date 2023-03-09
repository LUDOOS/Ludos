using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAudio : MonoBehaviour
{
    AudioHandler aHandler;
    [SerializeField] AudioClip clip;

    void Start()
    {
        aHandler = GameObject.Find("Background").GetComponent<AudioHandler>();
    }

    private void OnMouseUpAsButton()
    {
        aHandler.PlayAudio(clip);
    }

}
