using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    [SerializeField] private float minimumDistance = 0.0002f;
    [SerializeField] private float maximumTime = 1.5f;

    private float verticalDirectionThreshold = 0.3f; 
    private float horizontalDirectionThreshold = 0.4f;


    [SerializeField] private PlayerController playerController;
    private InputManager inputManager;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private float startTime;
    private float endTime;

    private void Awake()
    {
  
        Debug.Log("SwipeDetection awake");
        inputManager = InputManager.Instance;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (inputManager == null)
        {
            Debug.Log("Error: InputManager is null");
        }
    }

    private void OnEnable()
    {
        Debug.Log("Swipe Detection Enabled");
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
 
    }

    private void OnDisable()
    {
        Debug.Log("Swipe Detection Disabled");
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10f));
        startTime = time;
        Debug.Log($"Swipe started at screen position: {startPosition}");
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10f));
        endTime = time;
        Debug.Log($"Swipe ended at screen position: {endPosition}");
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        float distance = Vector2.Distance(startPosition, endPosition);
        float timeElapsed = endTime - startTime;

        Vector2 Direction = (endPosition-startPosition).normalized;

        Debug.Log($"Start Position: {startPosition}, End Position: {endPosition}");
        Debug.Log($"Distance: {distance}, Time Elapsed: {timeElapsed}, Direction: {Direction}");

        if (timeElapsed <= maximumTime && distance >= minimumDistance)
        {
            SwipeDirection(Direction);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        float absX = Mathf.Abs(direction.x);
        float absY = Mathf.Abs(direction.y);
        Debug.Log($"absX: {absX} absY: {absY}");

    if (absY > absX)
        {
            if (Vector2.Dot(Vector2.up, direction) > verticalDirectionThreshold)
            {
                Debug.Log("Swipe: Up");
                playerController.Jump();
            }
            else if (Vector2.Dot(Vector2.down, direction) > verticalDirectionThreshold)
            {
                Debug.Log("Swipe: Down");
            }
        }
    else
        {
            if (Vector2.Dot(Vector2.right, direction) > horizontalDirectionThreshold)
            {
                Debug.Log("Swipe: Right");
                playerController.MoveRight();
            }
            else if (Vector2.Dot(Vector2.left, direction) > horizontalDirectionThreshold)
            {
                Debug.Log("Swipe: Left");
                playerController.MoveLeft();
            }
        }
    }
}
