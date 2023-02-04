using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player _player;
    float _jumpForce = 8.3f;
    float _leftMovement = -1f;
    float _rightMovement = 1f;
    float _speedMovement = 1.2f;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Awake();
    }

    public void jumpToTheLeft()
    {
        if (_player.isGrounded)
        {
            _player.isGrounded = false;
            _player.GetComponent<Rigidbody2D>().velocity = new Vector2(_leftMovement * _speedMovement,_jumpForce);
            //_player.transform.Translate(_leftMovement,_jumpForce,0f);
        }
    }
    public void jumpToTheRight()
    {
        if (_player.isGrounded)
        {
            _player.isGrounded = false;
            _player.GetComponent<Rigidbody2D>().velocity = new Vector2(_player.transform.position.x, _jumpForce);
            //_player.transform.Translate(_rightMovement, _jumpForce, 0f);
        }
    }
}
