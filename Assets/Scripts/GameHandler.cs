using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class GameHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputActionReference actionReference;

    private bool isMiddleMouseButtonHeldDown;

    private void Start()
    {
   
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PingSystem.Initialize();

        // For ping
        PingStartAssets playerInputActions = new PingStartAssets();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Ping.performed += Ping;

        // For ping wheel held down
        PingWheelStartAssets pingWheelStartAssters = new PingWheelStartAssets();
        pingWheelStartAssters.Enable();
        pingWheelStartAssters.Player.PingWheel.performed += PingWheel;
        //pingWheelStartAssters.Player.PingWheel.canceled += PingWheel;

        // For ping wheel released
        PingWheelReleasedStarterAssets pingWheelReleasedStarterAssetes = new PingWheelReleasedStarterAssets();
        pingWheelReleasedStarterAssetes.Enable();
        pingWheelReleasedStarterAssetes.Player.PingWheelReleased.performed += PingWheelReleased;
    }
    private void Update()
    {

        //if (Mouse.current.middleButton.wasPressedThisFrame)
        //{
        //    PingSystem.AddPing(Mouse3D.GetMouseWorldPosition());
        //}

        //if (Mouse.current.middleButton.wasPressedThisFrame)
        //{
        //    PingSystem.PingButtonHeldDown();
        //}

        ////if (Mouse.current.middleButton.wasReleasedThisFrame)
        //{
        //    PingSystem.PingButtonReleased();
        //}

        PingSystem.Update();

        //if (Keyboard.current.fKey.wasPressedThisFrame)
        //{
        //    PingSystem.AddPing(new PingSystem.Ping(PingSystem.Ping.Type.Enemy, Mouse3D.GetMouseWorldPosition()));
        //}
        
    }

    public void Ping(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        if (context.performed)
        {
            PingSystem.AddPing(Mouse3D.GetMouseWorldPosition());
        }
    }

    // Holds Middle Mouse button
    public void PingWheel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PingSystem.PingButtonHeldDown();
            Debug.Log("Middle mouse button is held down");
        }

    }

    public void PingWheelReleased(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PingSystem.PingButtonReleased();
            Debug.Log("Middle mouse button is released");
        }
    }
}
