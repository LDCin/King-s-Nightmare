using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sr;
    [SerializeField] private GameObject _detectZone;
    [SerializeField] private int _hP = 2;
    [SerializeField] private float _invulnerableTime = 0.5f;
    private float _invulnerableTimer = 0f;
    [SerializeField] private Rigidbody2D _bombPrefab;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private float _flightTime = 1.2f;
    [SerializeField] private float _attackCooldown = 2f;
    private Transform _playerTarget;
    private float _attackTimer = 0;
    private bool _isAttacking = false;
    private bool _lostTargetWhileAttacking = false;
    private Vector3 _lockedTargetPos;
    [SerializeField] private GameObject _dialogue;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        // _throwPoint = transform;
        _invulnerableTimer = _invulnerableTime;
    }
    public void Update()
    {
        if (_invulnerableTimer < _invulnerableTime) _invulnerableTimer += Time.deltaTime;
        if (_playerTarget == null) return;
        if (_playerTarget != null && !_isAttacking) FaceToPlayer();
        _attackTimer += Time.deltaTime;
        if (_attackTimer >= _attackCooldown)
        {
            _attackTimer = 0;
            _isAttacking = true;
            _lostTargetWhileAttacking = false;
            _lockedTargetPos = _playerTarget.position;
            _anim.SetTrigger(GameConfig.ATTACK_TRIGGER);
        }
    }
    public void FaceToPlayer()
    {
        if (transform.position.x - _playerTarget.position.x < 0)
        {
            _sr.flipX = true;
        }
        else _sr.flipX = false;
    }
    public void TakeDamage(int damage)
    {
         if (_invulnerableTimer < _invulnerableTime) return;
        _invulnerableTimer = 0;
        _anim.SetTrigger(GameConfig.HIT_TRIGGER);
        _hP -= damage;
        if (_hP <= 0)
        {
            _anim.SetBool(GameConfig.DEAD_BOOL, true);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void ThrowBomb(Vector3 pos)
    {
        Rigidbody2D bomb = Instantiate(_bombPrefab, _throwPoint.position, Quaternion.identity);
        Vector2 startPos = bomb.position;
        Vector2 targetPos = pos;
        float gravity = Physics2D.gravity.y * bomb.gravityScale;
        float velocityX = (targetPos.x - startPos.x) / _flightTime;
        float velocityY = (targetPos.y - startPos.y - 0.5f * gravity * _flightTime * _flightTime) / _flightTime;
        Vector2 velocity = new Vector2(velocityX, velocityY);
        bomb.velocity = Vector2.zero;
        bomb.AddForce(velocity, ForceMode2D.Impulse);
    }
    public void OnPlayerDetected(Transform player)
    {
        _playerTarget = player;
        _attackTimer = _attackCooldown / 2;
    }
    public void OnLossDetected()
    {
        if (_isAttacking) {
            _lostTargetWhileAttacking = true;
            return;
        }
        _playerTarget = null;
    }
    public void StartAttack()
    {
        if (_playerTarget != null) _lockedTargetPos = _playerTarget.position;
        ThrowBomb(_lockedTargetPos);
    }
    public void EndAttack()
    {
        _isAttacking = false;
        if (_lostTargetWhileAttacking)
        {
            _playerTarget = null;
            _lostTargetWhileAttacking = false;
        }
    }
    public void TurnOnDialogue()
    {
        _dialogue.SetActive(true);
    }
    public void TurnOffDialogue()
    {
        _dialogue.SetActive(false);
    }
}
