using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public static class PingSystem
{
    private const float Move_Enemy_Double_Click_Time = 0.05f;
    private const float Ping_Button_Held_Down_Time = 1f;

    private static float lastPingTime;
    private static Ping lastPing;

    private static List<Ping> pingList;
    private static float pingButtonHoldDownTimer;

    public static void Initialize()
    {
        pingList = new List<Ping>();
    }

    public static void AddPing(Vector3 position)
    {
        //Last ping was a Going here ping
        if (lastPing != null && lastPing.GetPingType() == Ping.Type.Move)
        {
            if (Time.time < lastPingTime + Move_Enemy_Double_Click_Time)
            {
                //Pings in succession
                DestroyPing(lastPing);
                AddPing(new Ping(Ping.Type.Enemy, position));
            }
            else
            {
                AddPing(new Ping(Ping.Type.Move, position));
            }
        }
        else
        {
            AddPing(new Ping(Ping.Type.Move, position));
        }
         
    }

    //Destroys recent ping
    public static void DestroyLastPing()
    {
        DestroyPing(lastPing);
    }

    //Destroys ping
    public static void DestroyPing(Ping ping)
    {
        ping.SelfDestroy();
        pingList.Remove(ping);
    }


    public static void AddPing(Ping ping)
    {
        pingList.Add(ping);

        Transform pingTransform = UnityEngine.Object.Instantiate(GameAssets.i.PingWorld, ping.GetPosition(), Quaternion.identity);

        switch (ping.GetPingType())
        {
            default:
                case Ping.Type.Move:
                break;

                case Ping.Type.Enemy:
                //pingTransform.GetComponent<SpriteRenderer>().sprite = GameAssets.i.pingEnemySprite;
               // pingTransform.Find("distanceText").GetComponent<TextMeshPro>().color = GameAssets.i.pingEnemyColour;
                break;

        }

        ping.OnDestroyed += delegate (object sender, EventArgs e)
        {
            UnityEngine.Object.Destroy(pingTransform.gameObject);
        };

        PingWindow.instance.AddPing(ping);

        lastPing = ping;
        lastPingTime = Time.time;
    }

    public static void Update()
    {
        for (int i = 0; i < pingList.Count; i++)
        {
            Ping ping = pingList[i];

            if (Time.time > ping.GetDestroyTime())
            {
                // Time to destroy ping
                DestroyPing(ping);
                i--;
            }
        }
    }

    public static void PingButtonHeldDown()
    {
        pingButtonHoldDownTimer += Time.deltaTime;

        // Show the ping wheel
        if(pingButtonHoldDownTimer > Ping_Button_Held_Down_Time)
        {
            if (!PingWheel.IsVisibleStatic())
            {
                PingWheel.ShowStatic(Mouse3D.GetMouseWorldPosition());
            }
        }
    }

    public static void PingButtonReleased()
    {
        pingButtonHoldDownTimer = 0f;
    }

    // Class for Ping variables and functions
    public class Ping 
    {
        public enum Type { 
            Move,
            Enemy,
        }

        public event EventHandler OnDestroyed;

        private Type type;
        private Vector3 position;
        private bool isDestroyed;
        private float destroyTime;

        public Ping(Type type, Vector3 position)
        {
            this.type = type;
            this.position = position;
            isDestroyed = false;
            destroyTime = Time.time + 5f;
        }
    
        //Function to return ping type
        public Type GetPingType()
        {
            return type;
        }

        // Function to return ping position
        public Vector3 GetPosition()
        {
            return position;
        }

        public void SelfDestroy()
        {
            isDestroyed = true;
            if (OnDestroyed != null) OnDestroyed(this, EventArgs.Empty);
        }

        public bool IsDestroyed()
        {
            return isDestroyed;
        }

        public float GetDestroyTime()
        {
            return destroyTime;
        }
    }

}
