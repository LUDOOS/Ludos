using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAudio : MonoBehaviour
{
    [SerializeField] AudioHandler handler;
    [SerializeField] AudioClip clip;


    private void OnMouseUpAsButton()
    {
        handler.PlayAudio(clip);
    }

}
