using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController :MonoBehaviour
{
    public AudioClip[] audioclips;
    public AudioSource audioSource;
    private void Start()
    {
      
        audioSource.PlayOneShot(audioclips[0]);
    }
    public void ChangeClip(int clipNumber) {
      audioSource.PlayOneShot(audioclips[clipNumber]);
    }
}
