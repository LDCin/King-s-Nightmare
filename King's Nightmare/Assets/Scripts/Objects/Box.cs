using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(GameConfig.BOMB_TAG) || other.collider.CompareTag(GameConfig.CANNON_BALL_TAG))
        {
            _anim.SetTrigger(GameConfig.EXPLODE_TRIGGER);
        }
    }
    private void Explode()
    {
        Destroy(gameObject);
    }
}
