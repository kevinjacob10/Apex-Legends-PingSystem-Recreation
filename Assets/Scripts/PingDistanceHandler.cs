using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PingDistanceHandler : MonoBehaviour
{
    private GameObject Player;

    private TextMeshProUGUI distanceText;

    private void Awake()
    {
        distanceText = GetComponent<TextMeshProUGUI>();
        Player = FindObjectOfType <ThirdPersonShooterController>().gameObject;
    }

    private void Update()
    {
        // Ping is parent of distance text
        Vector3 pingPosition = transform.parent.transform.position;

        Vector3 playerPosition = Player.transform.position;

        int distance = Mathf.RoundToInt(Vector3.Distance(pingPosition, playerPosition)/ 2f);
        distanceText.text = distance + "M";

    }
}
