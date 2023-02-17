using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    AnimalsPlayer _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<AnimalsPlayer>();
    }

    private void OnMouseUpAsButton()
    {
        _audio.Play();
        StartCoroutine(moveCameraToNextQuestion());
    }

    IEnumerator moveCameraToNextQuestion()
    {
        yield return new WaitForSeconds(1f);
        _player.move();
    }
}
