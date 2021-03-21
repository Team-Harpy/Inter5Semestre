using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{


    private float playerSpeed;
    [SerializeField]
    private float walkSpeed = 5.0f;
    [SerializeField]
    private float sprintSpeed = 10.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;


    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    private Light flashlight;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        Cursor.visible = false;
        flashlight = cameraTransform.GetComponentInChildren<Light>();
        
    }

    void Update()
    {


        groundedPlayer = controller.isGrounded;

        // Keep Player Grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        //Sprint
        if (inputManager.PlayerSprinting())
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }




        // Player Move (WASD or ArrowKeys)
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
     
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Player Jump

       /* if (inputManager.PlayerJumpedInThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
       */


        //Flashlight Action
        if (inputManager.FlashlightAction())
        {
            flashlight.enabled = !flashlight.enabled;
        }

        // Gravity Adding
        playerVelocity.y += gravityValue * Time.deltaTime;


        controller.Move(playerVelocity * Time.deltaTime);
    }
}
