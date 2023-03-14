using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmmount = 10;
    [SerializeField]
    private CinemachineVirtualCamera aimVCam;
    [SerializeField]
    private Canvas ThirdPCanvas;
    [SerializeField]
    private Canvas aimCanvas;

    private InputAction aimAction;

    private void Awake()
    {
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
        aimVCam.Priority += priorityBoostAmmount;
        aimCanvas.enabled = true;
        ThirdPCanvas.enabled = false;
    }

    private void StopAim()
    {
        aimVCam.Priority -= priorityBoostAmmount;
        aimCanvas.enabled = false;
        ThirdPCanvas.enabled = true;
    }
}