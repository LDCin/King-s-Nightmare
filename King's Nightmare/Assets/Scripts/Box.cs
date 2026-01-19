using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private int _hP;
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConfig.BOMB_TAG))
        {
            _anim.SetTrigger(GameConfig.EXPLODE_TRIGGER);
        }
    }
    private void Explode()
    {
        Destroy(gameObject);
    }
}
