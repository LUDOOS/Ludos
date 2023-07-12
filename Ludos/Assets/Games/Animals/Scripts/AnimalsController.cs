using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsController : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    AnimalsPlayer _player;
    AudioHandler _aHandler;
    AnimalsUiManager _uiManager;
    bool isClicked = true;
    private static int stars = 0;
    static bool[] completeStatus = { false, false, false, false, false };
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<AnimalsPlayer>();
        _uiManager = GameObject.Find("Canvas").GetComponent<AnimalsUiManager>();
        _aHandler = GameObject.Find("hamada").GetComponent<AudioHandler>();
        scene = SceneManager.GetActiveScene();
    }

    private void OnMouseUpAsButton()
    {
        if (this.gameObject.name == "Animal" && _clip.name == "right")
        {
            if (isClicked) 
            {
                stars++;
                Debug.Log(stars + " the right animal");
                isClicked = false;
                PlayMyAudio('p');
            }
        }
        else if (this.gameObject.name == "FinalAnimal")
        {
            if (isClicked)
            {
                isClicked = false;
                stars++;
                Debug.Log(stars + " final animal");
                PlayMyAudio('s');
            }
        }
        else
        {
            _aHandler.PlayAudio(_clip);
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
            StartCoroutine(UpdateLevels());
            
        }
    }

    IEnumerator moveCameraToNextQuestion()
    {
        yield return new WaitForSeconds(2.5f);
        _player.move();
        isClicked = true;
    }

    IEnumerator FinishingLevel()
    {
        yield return new WaitForSeconds(1.5f);
        _uiManager.confetti.enabled = true;
        _uiManager.UpdateStars(stars);
        _uiManager.StopTimer();
        _uiManager.congrats.gameObject.SetActive(true);
        
    }

    IEnumerator UpdateLevels()
    {
        yield return StartCoroutine(FinishingLevel());
        if (!completeStatus[GameManager.instance.animalsCurrentLevel])
        {
            completeStatus[GameManager.instance.animalsCurrentLevel] = true;
            GameManager.instance.UpdateData(GameName: "animals", level: GameManager.instance.animalsCurrentLevel, stars: stars);
        }

        stars = 0;
    }

}
