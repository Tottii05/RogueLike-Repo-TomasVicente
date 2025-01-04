using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public Vector2 direction;
    public Rigidbody2D rb;
    public Weapon weapon { get; set; }
    public float timer = 0f;
    public float duration = 0.7f;
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float explosionRadius = 0.5f;
    public Sprite tempSprite;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPoint = transform.position;
        direction = transform.right;
        endPoint = startPoint + direction * 6f;

        var player = GameObject.Find("WeaponPlace");
        if (player != null)
        {
            var playerAttack = player.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                weapon = playerAttack.weapon;
            }
        }
    }


    void Update()
    {
        ParabolicMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Grenade hit " + other.name);
        Explode();
    }

    public void ParabolicMovement()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);
        float x = Mathf.Lerp(startPoint.x, endPoint.x, t);
        float height = 2f;
        float y = Mathf.Lerp(startPoint.y, endPoint.y, t) + height * (1 - Mathf.Pow(2 * t - 1, 2));
        transform.position = new Vector2(x, y);

        if (timer > 0)
        {
            Vector2 velocity = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (t >= 1f)
        {
            Explode();
        }
    }

    private HashSet<Collider2D> damagedEnemies = new HashSet<Collider2D>();

    void Explode()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletPlayer"), LayerMask.NameToLayer("Player"), true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var hit in hitEnemies)
        {
            if (hit.gameObject.layer != LayerMask.NameToLayer("Player") && !damagedEnemies.Contains(hit))
            {
                damagedEnemies.Add(hit);

                if (hit.TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable.TakeDamage(weapon.damage);
                }
                var rbEnemy = hit.GetComponent<Rigidbody2D>();
                if (rbEnemy != null)
                {
                    Vector2 pushDirection = (rbEnemy.transform.position - transform.position).normalized;
                    float pushForce = 10f;
                    rbEnemy.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                }
            }
        }
        StartCoroutine(EplodeAnimCoroutine());
    }

    public IEnumerator EplodeAnimCoroutine()
    {
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Explode", false);
        Destroy(gameObject);
    }
        
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
