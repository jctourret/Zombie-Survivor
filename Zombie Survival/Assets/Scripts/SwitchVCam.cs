using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmmount = 10;

    private CinemachineVirtualCamera vCam;
    private InputAction aimAction;

    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => StopAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ =>StartAim();
        aimAction.canceled -= _  =>StopAim();
    }

    private void StartAim()
    {
        vCam.Priority += priorityBoostAmmount;
    }

    private void StopAim()
    {
        vCam.Priority -= priorityBoostAmmount;
    }
}
