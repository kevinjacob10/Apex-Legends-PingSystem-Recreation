using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PingSystem 
{
    public static void AddPing(Vector3 position)
    {
        Object.Instantiate(GameAssets.i.PingWorld, position, Quaternion.identity);
        PingWindow.AddPing(position);
    }
}
