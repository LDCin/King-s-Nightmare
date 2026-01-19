using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour
{
    [SerializeField] private Pig pig;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConfig.PLAYER_TAG))
        {
            pig.OnPlayerDetected(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConfig.PLAYER_TAG))
        {
            pig.OnLossDetected();
        }
    }
}
