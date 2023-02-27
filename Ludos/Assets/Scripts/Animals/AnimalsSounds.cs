using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSounds : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    AnimalsPlayer _player;
    AudioHandler _aHandler;
    AnimalsUiManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<AnimalsPlayer>();
        _uiManager = GameObject.Find("Canvas").GetComponent<AnimalsUiManager>();
        _aHandler = GameObject.Find("Background").GetComponent<AudioHandler>();
    }

    private void OnMouseUpAsButton()
    {
        _aHandler.PlayAudio(_clip);
        if (this.gameObject.name == "Animal" && _clip.name == "right")
        {
            PlayMyAudio('p');
        }
        else if (this.gameObject.name == "FinalAnimal")
        {
            PlayMyAudio('s');
        }
    }

    void PlayMyAudio(char state)
    {
        _aHandler._audio.Stop();
        _aHandler.PlayAudio(_clip);
        if (_aHandler._audio.isPlaying && state == 'p')
        {
            StartCoroutine(moveCameraToNextQuestion());
        }
        else if(state == 's')
        {
            StartCoroutine(FinishingLevel());
        }
    }

    IEnumerator moveCameraToNextQuestion()
    {
         yield return new WaitForSeconds(2.5f);
         _player.move(); 
    }

    IEnumerator FinishingLevel()
    {
        yield return new WaitForSeconds(1.5f);
        _uiManager.confetti.enabled = true;
        _uiManager.congrates.gameObject.SetActive(true);
    }
}
