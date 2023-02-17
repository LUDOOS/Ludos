using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsPlayer : MonoBehaviour
{
    Vector3 _move;
    // Start is called before the first frame update
    void Start()
    {
        _move = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void move()
    {
        _move.x += 5.2f;
        transform.position = _move;
    }
}
