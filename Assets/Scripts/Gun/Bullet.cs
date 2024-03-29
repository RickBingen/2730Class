using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] int _damageAmount = 1;
    [SerializeField] float _knockBackThrust = 20f;

    Vector2 _fireDirection;

    Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _fireDirection * _moveSpeed;
    }

    public void Init(Vector2 bulletSpawnPos, Vector2 mousePos)
    {
        _fireDirection = (mousePos - bulletSpawnPos).normalized;
        float angle = Mathf.Atan2(_fireDirection.y, _fireDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Health health = other.gameObject.GetComponent<Health>();
        health?.TakeDamage(_damageAmount);

        Knockback knockback = other.gameObject.GetComponent<Knockback>();
        knockback?.GetKnockedBack(PlayerController.Instance.transform.position, _knockBackThrust);

        Flash flash = other.gameObject.GetComponent<Flash>();
        flash?.StartFlash();
        
        Destroy(gameObject);
    }
}