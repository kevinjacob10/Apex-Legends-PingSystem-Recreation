using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PingUIHandler : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 pingPosition;
    private TextMeshPro distanceText;

    [SerializeField]
    private GameObject Player;

    public void Setup(Vector3 pingPosition)
    {
        this.pingPosition = pingPosition;
        rectTransform = transform.GetComponent<RectTransform>();
        distanceText = transform.Find("distanceText").GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        // Updates UI position
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (pingPosition - fromPosition).normalized;

        float uiRadius = 270f;
        rectTransform.anchoredPosition = dir * uiRadius;


        // Updates ping distance text
        Vector3 playerPosition = Player.transform.position;

        int distance = Mathf.RoundToInt(Vector3.Distance(pingPosition, playerPosition) / 3f);
        distanceText.text = distance + "M";
    }
}
