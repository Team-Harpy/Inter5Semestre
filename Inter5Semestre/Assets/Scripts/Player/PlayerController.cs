﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool interacting;

    [Header("Movimentação")]
    [SerializeField]
    private float walkSpeed = 5.0f;
    private float playerSpeed;
    [SerializeField]
    private float sprintSpeed = 10.0f;
    [SerializeField]
    private float crouchSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [Header("Flashlight")]
    public bool flashlightOn;
    [HideInInspector]
    public bool hasFlashlight = true;
    public float flashlightTimer;
    private float flashlightTimerI;
    [SerializeField]
    private float flashlightDepletionRate;
    [SerializeField]
    private float flashlightRecoveryRate;
    public Light flashlight;
    public float chanceToFail;
    [HideInInspector]
    public bool flashlightCanFail = false;

    [Header("Monstro")]
    [SerializeField]
    private GameObject monstro;
    [SerializeField]
    private Transform monstroSpawn;

    [Header("Outros")]
    public float rangeIteracao;
    [SerializeField]
    private LightingManager lightingManager;
    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    [HideInInspector]
    public bool groundedPlayer;
    private Transform cameraTransform;
    public GameObject interagivelInstrucoes;
    public GameObject caixasInstrucoes;
    public GameObject portaInstrucoes;

    [SerializeField]
    private CinemachineVirtualCamera normalCamera;
    [SerializeField]
    private CinemachineVirtualCamera crouchCamera;


    private bool crouchcameraAdjust;
    private bool normalcameraAdjust;

    public LayerMask layerSelecao;
    Interactable selected;
    public GameObject interactText;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //flashlight = cameraTransform.GetComponentInChildren<Light>();
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
        if (!interacting)
        {
            Vector2 movement = inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0f, movement.y);
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;

            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        if (interacting)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!interacting)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
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

        if (flashlightCanFail)
        {
            if (flashlight.enabled)
            {
                int sorteio = Random.Range(0, 100);
                if (sorteio <= chanceToFail)
                {
                    flashlight.enabled = false;
                }
            }
        }

        //print(flashlightTimer);

        // Gravity Adding
        playerVelocity.y += gravityValue * Time.deltaTime;


        controller.Move(playerVelocity * Time.deltaTime);

        //Raycast
        Ray raio = Camera.main.ScreenPointToRay(inputManager.MousePosition());
        RaycastHit hit;
        Interactable newSelection = null;
        SelectHighlight highlight = null;
        Outline outline = null;
        CommentObject newObject = null;
        ZoomComment newZoom = null;
        CaixaEmpurra newBox = null;
        Debug.DrawRay(raio.origin, raio.direction * 10, Color.red);

        if (Physics.Raycast(raio, out hit, rangeIteracao, layerSelecao))
        {
            newSelection = hit.transform.GetComponent<Interactable>();
            newObject = hit.transform.GetComponent<CommentObject>();
            newZoom = hit.transform.GetComponent<ZoomComment>();
            newBox = hit.transform.GetComponent<CaixaEmpurra>();
        }

        if (selected)
        {
            if (selected.GetComponent<SelectHighlight>())
            {
                selected.GetComponent<SelectHighlight>().Off();
            }

            if (selected.GetComponent<Outline>())
            {
                selected.GetComponent<Outline>().enabled = false;
            }

            interactText.SetActive(false);
            caixasInstrucoes.SetActive(false);
            portaInstrucoes.SetActive(false);
            interagivelInstrucoes.SetActive(false);
        }

        if (newSelection)
        {
            highlight = newSelection.GetComponent<SelectHighlight>();
            if (highlight)
            {
                highlight.On();
            }

            outline = newSelection.GetComponent<Outline>();
            if (outline)
            {
                outline.enabled = true;
            }

            if (newSelection.CompareTag("Porta")) portaInstrucoes.SetActive(true);
            if (!newSelection.CompareTag("Porta") && !newSelection.CompareTag("Caixa")) interagivelInstrucoes.SetActive(true);

            selected = newSelection;
            interactText.SetActive(true);

            if(inputManager.Interact())
            {
                newSelection.Interact();
            }
        }

        if (newObject)
        {
            newObject.Comment();
        }

        if (newBox)
        {
            if (inputManager.Interact())
            {
                newBox.Empurra();
            }

            if (inputManager.PullBox())
            {
                newBox.Puxa();
            }
            caixasInstrucoes.SetActive(true);
        }

        //Debug.Log(selected);
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
