using UnityEngine;

public class Base : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _moveX = 0;
    private float _speed = 1f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _moveX = 1;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _rb.velocity = new Vector2(_moveX * _speed, _rb.velocity.y);
    }
    private void ChangeDirection()
    {
        _moveX *= -1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touch");
        if (collision.collider.CompareTag(GameConfig.GROUND_TAG) || 
            collision.collider.CompareTag(GameConfig.WALL_TAG) ||
                collision.collider.CompareTag(GameConfig.BASE_TAG) ||
                    collision.collider.CompareTag(GameConfig.SPECIAL_BASE_TAG))
        {
            ChangeDirection();
        }
    }
}
