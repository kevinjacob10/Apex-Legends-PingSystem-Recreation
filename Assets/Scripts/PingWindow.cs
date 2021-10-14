using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingWindow : MonoBehaviour
{
    public static PingWindow instance { get; private set; }

    private Transform localPingWindow;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        localPingWindow = LocalCanvas.Instance.pingWindow;
    }

    public void AddPing(PingSystem.Ping ping)
    {
        if (localPingWindow == null) return;
        Transform pingUItransform = Instantiate(GameAssets.i.PingUI, localPingWindow);
        pingUItransform.GetComponent<PingUIHandler>().Setup(ping);
    }
}
