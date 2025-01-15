using System;
using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour, IDamageable
{
    public int Hp = 100;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject weaponHolder;
    public Rigidbody2D rb;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(HurtAnim());
        if (Hp <= 0)
        {
            StartCoroutine(DeathCoroutine());
        }
    }

    public IEnumerator DeathCoroutine()
    {
        GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("Dead", true);
        weaponHolder.SetActive(false);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

    public IEnumerator HurtAnim()
    {  
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
