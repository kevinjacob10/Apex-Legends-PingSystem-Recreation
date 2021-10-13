using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCanvas : MonoBehaviour
{
    public static LocalCanvas Instance { get; private set; }

    public Camera EventCamera;

    public Transform pingWindow;

    private void Awake()
    {
        Instance = this;
    }
}
