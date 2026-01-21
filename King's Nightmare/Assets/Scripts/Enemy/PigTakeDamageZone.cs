using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTakeDamageZone : MonoBehaviour
{
    [SerializeField] private Pig _pig;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConfig.PLAYER_HITBOX))
        {
            _pig.TakeDamage(1);
        }
    }
}
