using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public Animator animator;
    public Weapon weapon;
    public GameObject audioManager;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        animator = GetComponent<Animator>();
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
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        audioManager.GetComponent<AudioManager>().PlaySFX(weapon.attackSound);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(weapon.damage);
        }
    }
}
