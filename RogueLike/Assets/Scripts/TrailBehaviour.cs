using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    private float speed = 50f;
    public Vector2 direction;
    public Rigidbody2D rb;
    public Weapon weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.right;
    }
    void Update()
    {
        ConstantMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(weapon.damage);
            Debug.Log(weapon.damage);
        }
        Destroy(gameObject);
    }

    public void ConstantMovement()
    {
        rb.velocity = direction * speed;
    }
}
