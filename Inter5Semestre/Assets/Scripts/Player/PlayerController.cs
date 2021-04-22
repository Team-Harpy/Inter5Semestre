using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{   

    private float playerSpeed;
    [SerializeField]
    private float walkSpeed = 5.0f;
    [SerializeField]
    private float sprintSpeed = 10.0f;
    [SerializeField]
    private float crouchSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private bool hasFlashlight = true;
    public bool flashlightOn;


    [SerializeField]
    private GameObject monstro;
    [SerializeField]
    private Transform monstroSpawn;

    private CharacterController controller;
    [SerializeField]
    private LightingManager lightingManager;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    [HideInInspector]
    public bool groundedPlayer;
    private Transform cameraTransform;
    private Light flashlight;

    public float flashlightTimer;
    private float flashlightTimerI;
    [SerializeField]
    private float flashlightDepletionRate;
    [SerializeField]
    private float flashlightRecoveryRate;

    [SerializeField]
    private CinemachineVirtualCamera normalCamera;
    [SerializeField]
    private CinemachineVirtualCamera crouchCamera;


    private bool crouchcameraAdjust;
    private bool normalcameraAdjust;

    public LayerMask layerSelecao;
    SelectHighlight selected;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        flashlight = cameraTransform.GetComponentInChildren<Light>();
        flashlight.enabled = false;

        flashlightTimerI = flashlightTimer;

    }

    void Update()
    {


        groundedPlayer = controller.isGrounded;

        // Keep Player Grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //Crouch
        if (inputManager.PlayerCrouching())
        {
            if (!crouchcameraAdjust)
            {
                crouchCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = normalCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value;
                crouchCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = normalCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
                crouchcameraAdjust = true;
                normalcameraAdjust = false;
            }

            playerSpeed = crouchSpeed;
            crouchCamera.Priority = 1;
            normalCamera.Priority = 0;

        }
        else
        {
            if (!normalcameraAdjust)
            {
                normalCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = crouchCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value;
                normalCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = crouchCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
                normalcameraAdjust = true;
                crouchcameraAdjust = false;
            }

            playerSpeed = walkSpeed;
            crouchCamera.Priority = 0;
            normalCamera.Priority = 1;
        }

        //Sprint
        if (inputManager.PlayerSprinting() && !inputManager.PlayerCrouching()) 
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
            if (!hasFlashlight) return;
           
            //Debug.Log("Tocou");
            flashlight.enabled = !flashlight.enabled;
            flashlightOn = !flashlightOn;
        }

        //Flashlight Cooldown
        if (flashlight.enabled == true)
        {
            flashlightTimer -= flashlightDepletionRate * Time.deltaTime;
        }

        if(flashlight.enabled == false)
        {
            flashlightTimer += flashlightRecoveryRate * Time.deltaTime;
            if (flashlightTimer >= flashlightTimerI)
                flashlightTimer = flashlightTimerI;
        }

        if(flashlightTimer <= 0)
        {
            flashlight.enabled = false;
            flashlightOn = false;
        }

        //print(flashlightTimer);

        // Gravity Adding
        playerVelocity.y += gravityValue * Time.deltaTime;


        controller.Move(playerVelocity * Time.deltaTime);

        //Raycast
        Ray raio = Camera.main.ScreenPointToRay(inputManager.MousePosition());
        RaycastHit hit;
        SelectHighlight newSelection = null;
        CommentObject newObject = null;
        Debug.DrawRay(raio.origin, raio.direction * 10, Color.red);

        if (Physics.Raycast(raio, out hit, 10, layerSelecao))
        {
            newSelection = hit.transform.GetComponent<SelectHighlight>();
            newObject = hit.transform.GetComponent<CommentObject>();
        }

        if (selected)
        {
            selected.Off();
        }

        if (newSelection)
        {
            newSelection.On();
            selected = newSelection;

            Interactable novo = newSelection.GetComponent<Interactable>();
            if(novo && inputManager.Interact())
            {
                novo.Interact();
            }
        }

        if (newObject)
        {
            newObject.Comment();
        }

        
       
    }


    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.CompareTag("Flashlight"))
        {
            hasFlashlight = true;
            lightingManager.NightTime();
            Destroy(other.gameObject);
        }

        /*if (other.gameObject.CompareTag("MonsterTrigger"))
        {
            Debug.Log("Ativou Monstro");
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MonsterTrigger"))
        {
            Instantiate(monstro, monstroSpawn.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
