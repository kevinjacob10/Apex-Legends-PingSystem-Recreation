using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UI.Buttons;

public class PingWheel : MonoBehaviour
{
    private static PingWheel instance;

    private Vector3 pingPosition;

    [SerializeField]
    private Button_UI moveBtn;

    private void Awake()
    {
        instance = this;

        moveBtn.ClickFunc = () =>
        {
            PingSystem.AddPing(new PingSystem.Ping(PingSystem.Ping.Type.Move, pingPosition));
        };

        Hide();
    }

    private void Show(Vector3 pingPosition)
    {
        this.pingPosition = pingPosition;
        gameObject.SetActive(true);
        PingSystem.DestroyLastPing();
    }

    private void Hide()
    {
        Debug.Log("Hide");
        gameObject.SetActive(false);
    }

    public static void ShowStatic(Vector3 pingPosition)
    {
        instance.Show(pingPosition);
    }

    public static void HideStatic()
    {
        instance.Hide();
    }

    public static bool IsVisibleStatic()
    {
        return instance.gameObject.activeSelf;
    }
}
