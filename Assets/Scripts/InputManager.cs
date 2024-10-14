using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements;

[DefaultExecutionOrder(-1)] // this script will run before any other script
public class InputManager : Singleton<InputManager>
{
    private Camera mainCamera;

    #region Events

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    private bool isTouching; // to keep track whether touch is active

    #endregion
    private TouchControls touchControls;

    protected override void Awake()
    {
        base.Awake();
        touchControls = new TouchControls();
        mainCamera = Camera.main;

        if (mainCamera == null )
        {
            Debug.Log("mainCamera is null.");
        }
        else
        {
            Debug.Log("mainCamera initialized.");
        }
    }
    private void OnEnable()
    {
        touchControls.Enable();
        Debug.Log("InputManager enabled, subscribing to events.");
    }
    private void OnDisable()
    {
        touchControls.Disable();
        Debug.Log("InputManager disabled, unsubscribing from events.");
    }
    void Start()
    {
        touchControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        touchControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        Debug.Log("Calling StartTouchPrimary()");
        Vector2 screenPosition = touchControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        Debug.Log($"Raw screen position at start of swipe: {screenPosition}");

        if (OnStartTouch != null)
        {
            OnStartTouch(Utils.ScreenToWorld(mainCamera, touchControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
        }
        else
        {
            Debug.Log("OnStartTouch is null!");
        }
        isTouching = true;
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        Debug.Log("Calling EndTouchPrimary()");
        if (isTouching)
        {
            if (OnEndTouch != null)
            {
                OnEndTouch(Utils.ScreenToWorld(mainCamera, touchControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
            }
            else
            {
                Debug.Log("OnEndTouch is null!");
            }
            isTouching= false; // resetting to false when touch ends
        }
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, touchControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

}
