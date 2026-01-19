using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTakeDamageZone : MonoBehaviour
{
    [SerializeField] private Pig _pig;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConfig.PLAYER_HITBOX))
        {
            _pig.TakeDamage(1);
        }
    }
}
