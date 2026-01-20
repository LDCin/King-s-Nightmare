using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    private Animator _anim;
    private Rigidbody2D _rb;
    private CircleCollider2D _cc;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _cc = GetComponent<CircleCollider2D>();
    }
    public int GetDamage()
    {
        return _damage;
    }
    public void TurnOffCollider()
    {
        _cc.gameObject.SetActive(false);
    }
    public void Explode()
    {
        _anim.SetTrigger(GameConfig.EXPLODE_TRIGGER);
        _rb.gravityScale = 0;
    }
    public void Disappear()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConfig.WALL_TAG) || 
            other.CompareTag(GameConfig.GROUND_TAG) || 
                other.CompareTag(GameConfig.PLAYER_TAG) ||
                    other.CompareTag(GameConfig.BASE_TAG) || 
                        other.CompareTag(GameConfig.SPECIAL_BASE_TAG))
        {
            _rb.velocity = Vector2.zero;
            Explode();
        }
    }
}
