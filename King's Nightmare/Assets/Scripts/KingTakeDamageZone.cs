using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingTakeDamageZone : MonoBehaviour
{
    [SerializeField] private King _king;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConfig.BOMB_TAG))
        {
            _king.TakeDamage(1);
        }
    }
}
