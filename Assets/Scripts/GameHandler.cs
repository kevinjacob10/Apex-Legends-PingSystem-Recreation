using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class GameHandler : MonoBehaviour
{
    private void Start()
    {
   
    }
    private void Update()
    {
        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            PingSystem.AddPing(Mouse3D.GetMouseWorldPosition());
        }
    }
}
