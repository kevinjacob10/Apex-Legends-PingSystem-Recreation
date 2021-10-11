using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PingDistanceHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private TextMeshPro distanceText;

    private void Awake()
    {
        distanceText = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        // Ping is parent of distance text
        Vector3 pingPosition = transform.parent.position;

        Vector3 playerPosition = Player.transform.position;

        int distance = Mathf.RoundToInt(Vector3.Distance(pingPosition, playerPosition) / 3f);
        distanceText.text = distance + "M";
    }
}
