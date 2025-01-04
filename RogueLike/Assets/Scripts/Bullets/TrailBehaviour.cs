using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    private float speed = 50f;
    public Vector2 direction;
    public Rigidbody2D rb;
    public Weapon weapon;

    void Start()
    {
        direction = transform.right;
        var player = GameObject.Find("WeaponPlace");
        if (player != null)
        {
            var playerAttack = player.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                weapon = playerAttack.weapon;
            }
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletPlayer"), LayerMask.NameToLayer("Player"), true);
        }
    }


    void Update()
    {
        ConstantMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trail hit " + other.name);
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(weapon.damage);
        }
        Destroy(gameObject);
    }

    public void ConstantMovement()
    {
        rb.velocity = direction * speed;
    }
}
