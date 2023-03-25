using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public float maxSwipeTime;
    public float minSwipeDistance;

    public float swipeTime;
    private float swipeStartTime;
    private float swipeEndTime;

    private float swipeLength;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;

    Vector3 _move;
    float _leftBoundary;
    float _rightBoundary;
    // Start is called before the first frame update
    void Start()
    {
        _move = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _leftBoundary = transform.position.x;
        _rightBoundary = _leftBoundary + 4.8f + 4.8f;
    }

    public void moveToTheRight()
    {
        if (_rightBoundary > _move.x)
        {
            _move.x += 4.8f;
            transform.position = _move;
        }

    }

    public void moveToTheLeft()
    {
        if (_leftBoundary <= _move.x)
        {
            _move.x -= 4.8f;
            transform.position = _move;
        }

    }

    private void Update()
    {
        swipeTest();
    }

    void swipeTest()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                swipeStartTime = Time.time;
                startSwipePosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                swipeEndTime = Time.time;
                endSwipePosition = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipeLength = (endSwipePosition - startSwipePosition).magnitude;
                if (swipeTime < maxSwipeTime && swipeLength > minSwipeDistance)
                {
                    swipeControl();
                }
            }
        }
    }
    void swipeControl()
    {
        Vector2 distance = endSwipePosition - startSwipePosition;
        float xDistance = Mathf.Abs(distance.x);
        float yDistance = Mathf.Abs(distance.y);
        if (xDistance > yDistance)
        {
            if (distance.x > 0)
            {
                moveToTheLeft();
            }
            else if (distance.x < 0)
            {
                moveToTheRight();
            }
        }
    }
}
