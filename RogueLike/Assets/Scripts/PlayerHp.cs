using System;
using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour, IDamageable
{
    public int Hp = 100;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject weaponHolder;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (Hp <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            animator.SetBool("Dead", true);
        }
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
        weaponHolder.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

    public IEnumerator HurtAnim()
    {  
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;

    }
}
