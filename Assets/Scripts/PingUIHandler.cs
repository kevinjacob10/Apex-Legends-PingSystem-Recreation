using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PingUIHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    private PingSystem.Ping ping;
    private Vector3 pingPosition;
    private TextMeshPro distanceText;
    private Image image;

    [SerializeField]
    private GameObject Player;

    public void Setup(PingSystem.Ping ping)
    {
        this.ping = ping;
        rectTransform = transform.GetComponent<RectTransform>();
        image = transform.GetComponent<Image>();
        distanceText = transform.Find("distanceText").GetComponent<TextMeshPro>();

        switch (ping.GetPingType())
        {
            default:
            case PingSystem.Ping.Type.Move:
                break;
            case PingSystem.Ping.Type.Enemy:
                image.sprite = GameAssets.i.pingEnemySprite;
                distanceText.color = GameAssets.i.pingEnemyColour;
                break;
        }
        ping.OnDestroyed += delegate (object sender, System.EventArgs e)
        {
            UnityEngine.Object.Destroy(gameObject);
        };
    }

    private void Update()
    {
        // To get screen coordinates
        if (ping == null) return;
        Vector3 pingScreenCoordinates = Camera.main.WorldToScreenPoint(ping.GetPosition());
        bool isOffScreen = pingScreenCoordinates.x > Screen.width || 
                           pingScreenCoordinates.x < 0 || pingScreenCoordinates.y > Screen.height ||
                           pingScreenCoordinates.y < 0;

        image.enabled = isOffScreen;
        distanceText.enabled = isOffScreen;


        if (isOffScreen)
        {
            // Updates UI position
            Vector3 fromPosition = Camera.main.transform.position;
            fromPosition.z = 0f;
            Vector3 dir = (ping.GetPosition() - fromPosition).normalized;

            float uiRadius = 270f;
            rectTransform.anchoredPosition = dir * uiRadius;


            // Updates ping distance text
            Vector3 playerPosition = Player.transform.position;

            int distance = Mathf.RoundToInt(Vector3.Distance(ping.GetPosition(), playerPosition) / 3f);
            distanceText.text = distance + "M";
        }
        else
        {
            // Ping is on screen and UI element is hidden
        }
        
    }
}
