using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDectection : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = 0.9f;

    private float minDistance = .2f;
    [SerializeField]
    private float maxTime = 1f;

    InputManager inputManager;

    Vector2 startPosition;
    float startTime;
    Vector2 endPosition;
    float endTime;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    void SwipeStart(Vector2 postion, float time)
    {
        startPosition = postion; startTime = time;
    }

    void SwipeEnd(Vector2 postion, float time)
    {
        endPosition = postion; endTime = time;
        DetectSwipe();
    }
    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("Swipe up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe down");
        }
    }
    private void DetectSwipe()
    { 
        if (Vector3.Distance(startPosition,endPosition) >= minDistance && 
            (endTime - startTime) <= maxTime)
        {
            Debug.Log("Swipe detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction3D = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction3D.x, direction3D.y).normalized;

            //SwipeDectection(direction2D);
        }
    }
}
