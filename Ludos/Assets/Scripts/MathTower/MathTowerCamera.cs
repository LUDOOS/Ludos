using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTowerCamera : MonoBehaviour
{
    [SerializeField]private MathTowerPlayer player;
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.y = player.transform.position.y + 2.5f;
        transform.position = tempPos ;
    }
}
