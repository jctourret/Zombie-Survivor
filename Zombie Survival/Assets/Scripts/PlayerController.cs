using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]
public class PlayerController: MonoBehaviour
{
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private Transform debugTransform;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float rotationSpeed = 3.0f;
    
    private CharacterController controller;
    private Transform cam;
    private Animator animator;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction aimAction;

    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;
    private bool groundedPlayer;
    private bool aimMode = false;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        aimAction = playerInput.actions["Aim"];
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        shootAction.performed += _ => Shoot();
        aimAction.performed += _ => LookForward();
        aimAction.canceled += _ => LookForward();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => Shoot();
        aimAction.performed -= _ => LookForward();
        aimAction.canceled -= _ => LookForward();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector2 input = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(input.x, 0, input.y).normalized;

        if (aimMode)
        {
            aimMovement(move);
        }
        else
        {
            if (move.magnitude > 0.1)
            {
                thirdPersonMovement(move);
            }
        }
        
        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void LookForward()
    {
        aimMode = !aimMode;
    }

    private void thirdPersonMovement(Vector3 move)
    {
        float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        controller.Move(move * playerSpeed * Time.deltaTime);
    }

    private void aimMovement(Vector3 move)
    {
        move = move.x * cam.transform.right + move.z * cam.transform.forward;
        move.y = 0;

        Quaternion targetRotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        controller.Move(move * Time.deltaTime * playerSpeed);

    }

    private void Shoot()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width/2,Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            if(debugTransform!= null)
            {
                debugTransform.position = hit.point;
            }
        }
    }
}