using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrailBehaviour : MonoBehaviour
{
    public int damage;
    public Rigidbody2D rb;
    public float speed = 15f;
    public Vector2 direction;
    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ConstantMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }
        enemy.GetComponent<EnemyAttack>().Push(gameObject);
    }

    public void SetDirection(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;
    }

    public void ConstantMovement()
    {
        rb.velocity = direction * speed;
    }
}
