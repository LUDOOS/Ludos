using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    AnimalsPlayer _player;
    AnimalsUiManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<AnimalsPlayer>();
        _uiManager = GameObject.Find("Canvas").GetComponent<AnimalsUiManager>();
    }

    private void OnMouseUpAsButton()
    {
        _audio.Play();
        if (this.gameObject.name == "Animal")
        {
            StartCoroutine(moveCameraToNextQuestion());
        }
        else if (this.gameObject.name == "FinalAnimal")
        {

            StopCoroutine(moveCameraToNextQuestion());
            _uiManager.congrates.gameObject.SetActive(true);
        }
    }

    IEnumerator moveCameraToNextQuestion()
    {
        yield return new WaitForSeconds(1f);
        _player.move();
    }
}
