using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsPlayer : MonoBehaviour
{
    Vector3 _move;
    [SerializeField] AudioClip _clip;
    AudioHandler _handler;
    // Start is called before the first frame update
    void Start()
    {
        _handler = GameObject.Find("Background").GetComponent<AudioHandler>();
        _move = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        StartCoroutine(PlayOpeningAudio());
    }

    public void move()
    {
        _move.x += 4.8f;
        transform.position = _move;
    }

    IEnumerator PlayOpeningAudio()
    {
        yield return new WaitForSeconds(2f);
        _handler.PlayAudio(_clip);
    }
}
