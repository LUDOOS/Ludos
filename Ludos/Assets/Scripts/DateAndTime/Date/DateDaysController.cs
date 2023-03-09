using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateDaysController : MonoBehaviour
{
    Transform mainCam;
    bool clicked = false;
    int target = 0;
    private int StarCounter = 0;
    public Image img;
    public Sprite [] sprites;
    public TextMeshProUGUI txt;
    Vector3[] pageLocations = new[] {
        new Vector3(0, 0, -10),
        new Vector3(6f, 0, -10), //Second Question Pos
        new Vector3(11.65f, 0, -10), //third Question Page Pos
        new Vector3(16.4f, 0, -10)
    };
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (clicked && target != 0)
        {
            moveTo(target);
        }

        
    }
    public void clickHandler(int target)
    {
        clicked = true;
        this.target = target;
    }
    public void moveTo(int game)
    {


        switch (game)
        {
            case 0:
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[0], 0.8f, mainCam));
                clicked = false;
                target = 0;
                break;
            case 1:
                Debug.Log("ttttttt");
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[1], 0.8f, mainCam));
                StarCounter ++;
                clicked = false;
                target = 0;
                break;
            case 2:
                Debug.Log("dateeee");
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[2], 1f, mainCam));
                StarCounter++;
               
                clicked = false;
                target = 0;
                break;
            case 3:
                Debug.Log("def");
                StartCoroutine(LerpFromTo(mainCam.position, pageLocations[3], 1f, mainCam));
                StarCounter++;
                updateFinalPage();
                clicked = false;
                target = 0;
                break;

    }
    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration, Transform test)
    {
        Debug.Log(pos2 + test.name);
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            test.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        test.position = pos2;
    }

    public void updateFinalPage() {
        if (StarCounter == 3)
        {
            img.sprite = sprites[3];
            txt.text = "Well Done You got Them All Right !";
        }
        else if (StarCounter == 2)
        {
            img.sprite = sprites[2];
            txt.text = "Good Job You got 2 correctly !!";
        }
        else if (StarCounter == 1)
        {
            img.sprite = sprites[1];
            txt.text = "Good Job You only Got One Right";
        }
        else if (StarCounter == 0)
        {
            img.sprite = sprites[0];
            txt.text = "You should rewatch the Story Video";
        }

        
    }
}
