using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    Transform mainCamPos;
    // Start is called before the first frame update
    void Start()
    {
        mainCamPos = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame

  public IEnumerator LerpFromTo(Vector3 pos2, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            mainCamPos.position = Vector3.Lerp(mainCamPos.position, pos2, t / duration);
            yield return 0;
        }
        mainCamPos.position = pos2;
    }
    public IEnumerator LerpFromTo(string gameObjectName,Vector3 pos2, float duration, float delay)
    {
        Transform temp = GameObject.Find(gameObjectName).transform;
        yield return new WaitForSeconds(delay);
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            temp.position = Vector3.Lerp(temp.position, pos2, t / duration);
            yield return 0;
        }
        temp.position = pos2;
    }
}
