using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour

{
    //public bool CanMove { get; private set; } = true;
    private bool isSprinting => canSprint && Input.GetKey(sprintKey);

    [Header("Functional Options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canInteract = true;
    [SerializeField] public bool CanMove = true;


    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode interact = KeyCode.E;
    [SerializeField] private KeyCode stopInteract = KeyCode.Q;



    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 6.0f;
    [SerializeField] private float SprintSpeed = 12.0f;
    [SerializeField] private float gravity = 30.0f;

    [Header("LookParameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float UpperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float LowerLookLimit = 80.0f;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    [Header("Interaction")]
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    private Interactable currentInteractable;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        CanMove = true;

    }

    void Update()
    {
        if(!PauseMenu.GameIsPaused)
        if(CanMove)
            {
                HandleMovementInput();
                HandleMouseLook();

                if(canInteract)
                {
                    handleInteractionCheck();
                    HandleInteractionInput();
                }

                
                ApplyFineMovement();
            }
        if (!CanMove)
            StopInteract();
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((isSprinting ? SprintSpeed : walkSpeed ) * Input.GetAxis("Vertical"), (isSprinting ? SprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward)*currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -UpperLookLimit, LowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX,0,0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);

        
    }

    private void handleInteractionCheck()
    {
        if (Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.gameObject.layer == 6 && (currentInteractable == null || (hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID())))
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                    currentInteractable.OnFocus();
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.onLoseFocus();
            currentInteractable = null;
        }  
        
}

    private void HandleInteractionInput()
    {
        if(Input.GetKeyDown(interact) && currentInteractable != null && Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, interactionLayer))
        {
            currentInteractable.onInteract();
            CanMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void StopInteract()
    {
        if (Input.GetKeyDown(stopInteract))
        {
            currentInteractable.stopInteract();
            CanMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void ApplyFineMovement()
    {
        if(!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
    