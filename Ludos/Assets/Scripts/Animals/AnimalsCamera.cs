using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsCamera : MonoBehaviour
{
    [SerializeField] private AnimalsPlayer player;
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.transform.position.x;
        transform.position = tempPos;
    }
}
