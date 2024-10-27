using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D player;
    private static int ballNum;
    private int maxBalls = 30;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == player)
        {
            if (ballNum < maxBalls)
            {
                GameObject duplicate = Instantiate(gameObject, transform.position, transform.rotation);
                ballNum ++;
            }
        }
    }
}
