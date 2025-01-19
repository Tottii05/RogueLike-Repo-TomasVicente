using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour, IDamageable
{
    public int Hp = 100;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject weaponHolder;
    public Rigidbody2D rb;
    public AudioClip takeDamageAudio;
    public GameObject audioManager;
    public AudioClip deathSound;
    public GameObject deathUI;
    public GameObject musicSource;
    public TextMeshProUGUI killCount;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager");
    }
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        audioManager.GetComponent<AudioManager>().PlaySFX(takeDamageAudio);
        StartCoroutine(HurtAnim());
        if (Hp <= 0)
        {
            StartCoroutine(DeathCoroutine());
        }
    }

    public IEnumerator DeathCoroutine()
    {
        killCount.text = GameObject.Find("GameManager").GetComponent<KillManager>().KilledEnemies.ToString();
        GetComponent<PlayerMovement>().enabled = false;
        musicSource.GetComponent<AudioSource>().volume = 0.01f;
        audioManager.GetComponent<AudioManager>().PlaySFX(deathSound);
        animator.SetBool("Dead", true);
        weaponHolder.SetActive(false);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        deathUI.SetActive(true);
    }

    public IEnumerator HurtAnim()
    {  
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
