using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float followRate;
    private Vector2 newPosition;

    private void Update()
    {
        newPosition = player.transform.position;

        newPosition = Vector3.Lerp(transform.position, newPosition, followRate);

        transform.position = newPosition;
    }
}
