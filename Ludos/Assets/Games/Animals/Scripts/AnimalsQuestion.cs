using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsQuestion : MonoBehaviour
{

    [SerializeField] AudioClip _clip;
    AudioHandler _handler;
    // Start is called before the first frame update
    void Start()
    {
        _handler = GameObject.Find("hamada").GetComponent<AudioHandler>();
    }

    private void OnMouseUpAsButton()
    {
        _handler._audio.Stop();
        _handler.PlayAudio(_clip);
    }

}
