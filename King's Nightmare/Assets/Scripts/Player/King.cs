using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class King : MonoBehaviour
{
    public static event Action OnPlayerDied;
    public static event Action OnPlayerWinGame;

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
    private float _initialGravityScale;
    // [SerializeField] private int _damage = 1;
    // private float _rayLength = 0.5f;
    [Header("Physics")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundBoxSize;
    [SerializeField] private Transform _hitBox;

    [Header("Logic Parameters")]
    private float _moveX = 0f;
    private float _moveY = 0f;
    private bool _canJump = false;
    private bool _isAttacking = false;
    private bool _isClimbing = false;
    private bool _isWaitingForClimbing = false;
    private bool _isDead = false;
    [SerializeField] private bool _isVulnarable = true;
    [SerializeField] private float _attackCooldown = 1;
    private float _attackTimer = 0;
    [SerializeField] private bool _canInteractGate = false;
    [SerializeField] private bool _canWin = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col2D = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _groundBoxSize = new Vector2(_col2D.bounds.size.x, 0.15f);
    }
    private void OnEnable()
    {
        GameManager.OnCanWin += ChangeToCanWinState;
    }
    private void OnDisable()
    {
        GameManager.OnCanWin -= ChangeToCanWinState;
    }
    private void Start()
    {
        _currentHP = _hP;
        _isDead = false;
        _initialGravityScale = _rb.gravityScale;
    }
    private void Update()
    {
        if (_isDead)
        {
            _moveX = 0;
            return;
        }
        if (_isWaitingForClimbing && !_isClimbing && Input.GetKey(KeyCode.W))
        {
            ChangeToClimbingState();
        }
        if (_isClimbing)
        {
            Climb();
        }
        else
        {
            Move();
        }
        if (Input.GetKeyDown(KeyCode.Space) && (IsOnGround() || _canJump))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _anim.SetTrigger(GameConfig.JUMP_TRIGGER);
        }
        if (Input.GetKey(KeyCode.E) && _canInteractGate)
        {
            Debug.Log("You Win");
            OnPlayerWinGame?.Invoke();
        }
    }
    private void FixedUpdate()
    {
        float x;
        float y;
        if (_isClimbing)
        {
            x = 0f;
            y = _moveY * _speed;
        }
        else
        {
            x = _isAttacking ? 0f : _moveX * _speed;
            y = _rb.velocity.y;
        }

        if (_baseRb != null && !_isClimbing)
        {
            x += _baseRb.velocity.x;
        }
        _rb.velocity = new Vector2(x, y);
    }
    private void Move()
    {
        _moveX = 0;
        _moveY = 0;
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move left");
            _moveX = -1;
            _sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move right");
            _moveX = 1;
            _sr.flipX = false;
        }
        else _moveX = 0;
        _anim.SetBool(GameConfig.RUN_BOOL, Mathf.Abs(_moveX) > 0.01f);

        // if (Input.GetKeyDown(KeyCode.Space) && (IsOnGround() || _canJump))
        // {
        //     _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        //     _anim.SetTrigger(GameConfig.JUMP_TRIGGER);
        // }

        _attackTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J) && !_isAttacking && _attackTimer >= _attackCooldown)
        {
            _isAttacking = true;
            _attackTimer = 0;
            _anim.SetTrigger(GameConfig.ATTACK_TRIGGER);
        }
    }
    private void Climb()
    {
        _moveX = 0;
        _moveY = 0;
        if (Input.GetKey(KeyCode.W))
        {
            _moveY = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _moveY = -1;
        }
        else _moveY = 0;
        if (Math.Abs(_moveY) > 0.01)
        {
            _anim.SetTrigger(GameConfig.CLIMB_TRIGGER);
        }
    }
    private void ChangeToClimbingState()
    {
        _isClimbing = true;
        _isWaitingForClimbing = false;
        _rb.gravityScale = 0;
        _anim.SetBool(GameConfig.CLIMB_IDLE_BOOL, true);
    }
    private void ChangeToNormalState()
    {
        _isClimbing = false;
        _rb.gravityScale = _initialGravityScale;
        _anim.SetBool(GameConfig.CLIMB_IDLE_BOOL, false);
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
    public void ChangeToCanWinState()
    {
        Debug.Log("Player can win now");
        _canWin = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConfig.ROPE_LADDER_TAG))
        {
            _isWaitingForClimbing = true;
            // float ladderCenterX = other.bounds.center.x;
            // _rb.position = new Vector2(ladderCenterX, _rb.position.y);
        }
        if (other.CompareTag(GameConfig.TOP_STEP_TAG))
        {
            _canJump = true;
        }
        if (other.CompareTag(GameConfig.GATE_TAG) && _canWin)
        {
            _canInteractGate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(GameConfig.ROPE_LADDER_TAG))
        {
            _isWaitingForClimbing = false;
            if (_isClimbing) ChangeToNormalState();
        }
        if (other.CompareTag(GameConfig.TOP_STEP_TAG))
        {
            _canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(GameConfig.SPECIAL_BASE_TAG) || other.collider.CompareTag(GameConfig.BASE_TAG))
        {
            _baseRb = other.collider.GetComponent<Rigidbody2D>();
            // transform.SetParent(other.transform);
        }
        else if (other.collider.CompareTag(GameConfig.ENEMY_TAG))
        {
            if (_isVulnarable)
            {
                TakeDamage(1);
            }
        }
        if (other.collider.CompareTag(GameConfig.BOMB_TAG) || other.collider.CompareTag(GameConfig.CANNON_BALL_TAG))
        {
            Bomb bomb = other.collider.GetComponent<Bomb>();
            if (_isVulnarable)
            {
                TakeDamage(bomb.GetDamage());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag(GameConfig.SPECIAL_BASE_TAG) || other.collider.CompareTag(GameConfig.BASE_TAG))
        {
            _baseRb = null;
            // transform.SetParent(null);
        }
    }
}
