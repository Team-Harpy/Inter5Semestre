using UnityEngine;


public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public bool PlayerJumpedInThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool PlayerSprinting()
    {
        return playerControls.Player.Sprint.activeControl != null;
    }

    public bool PlayerCrouching()
    {
        return playerControls.Player.Crouch.activeControl != null;
    }

    public bool FlashlightAction()
    {
        return playerControls.Player.Flashlight.triggered;
    }

    public bool DiaryUp()
    {
        return playerControls.Player.Diary.triggered;
    }

    public bool OpenMap()
    {
        return playerControls.Player.Map.triggered;
    }

    public bool Interact()
    {
        return playerControls.Player.Interact.triggered;
    }

    public bool ExitLock()
    {
        return playerControls.Player.ExitLock.triggered;
    }

    public bool NextDialogue()
    {
        return playerControls.Player.NextDialogue.triggered;
    }

    public Vector2 MousePosition()
    {
        return playerControls.Player.MousePosition.ReadValue<Vector2>();
    }

    /*
    public Vector2 GetMouseDelta()
    {
        return playerControls.Land.Look.ReadValue<Vector2>();
    }
    */


}

