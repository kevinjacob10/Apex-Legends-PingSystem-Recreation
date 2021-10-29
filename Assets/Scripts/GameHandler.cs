using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class GameHandler : MonoBehaviour
{

    private InputAction _input;

    private InputActionReference actionReference;

    private void Start()
    {
   
    }

    private void Awake()
    {
        PingSystem.Initialize();
    }
    private void Update()
    {
          
        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            PingSystem.AddPing(Mouse3D.GetMouseWorldPosition());
        }

        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            PingSystem.PingButtonHeldDown();
        }

        if (Mouse.current.middleButton.wasReleasedThisFrame)
        {
            PingSystem.PingButtonReleased();
        }

        PingSystem.Update();

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            PingSystem.AddPing(new PingSystem.Ping(PingSystem.Ping.Type.Enemy, Mouse3D.GetMouseWorldPosition()));
        }
        
    }

}
