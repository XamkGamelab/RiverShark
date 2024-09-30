using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] 
    private float minimumDistance = 0.1f;
    [SerializeField]
    private float maximumTime = 2f;
    [SerializeField, Range(0f,1f)]
    private float directionThreshold = 0.9f;
    [SerializeField]
    private PlayerController playerController;

    private InputManager inputManager;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float startTime;
    private float endTime;


    private void Awake()
    {
        inputManager = InputManager.Instance;

        if (inputManager == null)
        {
            Debug.Log("Error: InputManager is null");
        }
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

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        Debug.Log($"Swipe started at screen position: {startPosition}");
     
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
        Debug.Log($"Swipe ended at screen position: {endPosition}");
    }
    private void DetectSwipe()
    {
        // Convert screen coordinates to world coordinates for debugging purposes
        //Vector3 worldStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(startPosition.x, startPosition.y, Camera.main.nearClipPlane));
        //Vector3 worldEndPosition = Camera.main.ScreenToWorldPoint(new Vector3(endPosition.x, endPosition.y, Camera.main.nearClipPlane));

        float distance = Vector3.Distance(startPosition, endPosition);
        float timeElapsed = endTime - startTime;

        Vector3 Direction = endPosition - startPosition;
        Vector2 Direction2D = new Vector2(Direction.x, Direction.y).normalized;

        Debug.Log($"Start Position: {startPosition}, End Position: {endPosition}");
        Debug.Log($"Distance: {distance}, Time Elapsed: {timeElapsed}");
        

        if (distance >= minimumDistance && timeElapsed <= maximumTime)
        {
            SwipeDirection(Direction2D);
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold) {
            Debug.Log("Swipe: Up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe: Down");
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("Swipe: Left");
            playerController.MoveLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("Swipe: Right");
            playerController.MoveRight();
        }
    }
}
