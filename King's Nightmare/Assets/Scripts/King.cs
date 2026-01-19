using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public static event Action OnPlayerDied;

    [Header("Components")]
    private Rigidbody2D _rb;
    private Rigidbody2D _baseRb;

    private BoxCollider2D _col2D;
    private SpriteRenderer _sr;
    private Animator _anim;

    [Header("Stats")]
    [SerializeField] private int _hP = 3;
    private int _currentHP = 3;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpForce = 10f;
    // [SerializeField] private int _damage = 1;
    // private float _rayLength = 0.5f;
    [Header("Physics")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundBoxSize;
    [SerializeField] private Transform _hitBox;

    [Header("Logic Parameters")]
    private float moveX = 0f;

    private bool _isAttacking = false;
    private bool _isDead = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col2D = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _groundBoxSize = new Vector2(_col2D.bounds.size.x, 0.15f);
    }
    private void Start()
    {
        _currentHP = _hP;
        _isDead = false;
    }
    private void Update()
    {
        if (_isDead)
        {
            moveX = 0;
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
            _sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
            _sr.flipX = false;
        }
        else moveX = 0f;
        _anim.SetBool(GameConfig.RUN_BOOL, Mathf.Abs(moveX) > 0.01f);

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _anim.SetTrigger(GameConfig.JUMP_TRIGGER);
        }
        if (Input.GetKeyDown(KeyCode.J) && !_isAttacking)
        {
            _isAttacking = true;
            _anim.SetTrigger(GameConfig.ATTACK_TRIGGER);
        }
    }
    private void FixedUpdate()
    {
        float x = _isAttacking ? 0f : moveX * _speed;
        if (_baseRb != null)
        {
            x += _baseRb.velocity.x;
        }
        _rb.velocity = new Vector2(x, _rb.velocity.y);
    }

    private bool IsOnGround()
    {
        return Physics2D.OverlapBox(_groundCheck.position, _groundBoxSize, 0f, _groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        if (!_groundCheck) return;
        Gizmos.DrawWireCube(_groundCheck.position, _groundBoxSize);
    }
    public void StartAttack()
    {
        _hitBox.gameObject.SetActive(true);
    }
    public void EndAttack()
    {
        _hitBox.gameObject.SetActive(false);
        _isAttacking = false;
    }
    public void TakeDamage(int damage)
    {
        _anim.SetTrigger(GameConfig.HIT_TRIGGER);
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            _anim.SetBool(GameConfig.DEAD_BOOL, true);
            Die();
        }
    }
    public void Die()
    {
        _isDead = true;
        OnPlayerDied?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConfig.BOMB_TAG))
        {
            Bomb bomb = collision.GetComponent<Bomb>();
            TakeDamage(bomb.GetDamage());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(GameConfig.SPECIAL_BASE_TAG))
        {
            _baseRb = collision.collider.GetComponent<Rigidbody2D>();
            transform.SetParent(collision.transform);
        }
        else if (collision.collider.CompareTag(GameConfig.ENEMY_TAG))
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(GameConfig.SPECIAL_BASE_TAG))
        {
            _baseRb = null;
            transform.SetParent(null);
        }
    }
}
