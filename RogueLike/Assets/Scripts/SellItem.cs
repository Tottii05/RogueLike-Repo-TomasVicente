using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellItem : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public Weapon weapon;
    public GameObject player;
    public GameObject weaponHolder;
    public TextMeshProUGUI priceText;
    public GameObject audioManager;
    public AudioClip sellAudio;

    void Start()
    {
        player = GameObject.Find("Player");
        weaponHolder = GameObject.Find("WeaponPlace");
        weapon = GetComponent<RandomWeaponLoader>().choosedWeapon;
        audioManager = GameObject.Find("AudioManager");
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<MoneyManager>().coinCount >= weapon.price)
            {
                player.GetComponent<MoneyManager>().coinCount -= weapon.price;
                weaponHolder.GetComponent<PlayerAttack>().weapon = weapon;
                audioManager.GetComponent<AudioManager>().PlaySFX(sellAudio);
                Destroy(gameObject);
                Destroy(priceText.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
