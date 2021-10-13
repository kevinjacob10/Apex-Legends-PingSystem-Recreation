using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingWindow : MonoBehaviour
{
    private static PingWindow instance;

    private void Awake()
    {
        instance = this;
    }

    public static void AddPing(PingSystem.Ping ping)
    {
        Transform pingUItransform = Instantiate(GameAssets.i.PingUI, instance.transform);
        pingUItransform.GetComponent<PingUIHandler>().Setup(ping);
    }
}
