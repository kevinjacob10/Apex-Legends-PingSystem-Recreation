using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate() 
    {
        Quaternion rotation = Quaternion.LookRotation(cam.transform.forward, Vector3.up);
        transform.rotation = rotation;
    }
}
