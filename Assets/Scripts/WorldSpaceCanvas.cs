using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvas : MonoBehaviour
{
    private Canvas worldCanvas;
    
    private void Start()
    {
        worldCanvas = GetComponent<Canvas>();
        worldCanvas.worldCamera = LocalCanvas.Instance.EventCamera;
    }
}
