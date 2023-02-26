using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void PlayAudio(AudioClip clip)
    {

        if (!_audio.isPlaying)
        {
            _audio.PlayOneShot(clip);
        }
    }
}
