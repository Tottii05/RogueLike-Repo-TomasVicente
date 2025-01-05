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

    void Start()
    {
        player = GameObject.Find("Player");
        weaponHolder = GameObject.Find("WeaponPlace");
        weapon = GetComponent<RandomWeaponLoader>().choosedWeapon;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<MoneyManager>().coinCount >= weapon.price)
            {
                player.GetComponent<MoneyManager>().coinCount -= weapon.price;
                weaponHolder.GetComponent<PlayerAttack>().weapon = weapon;
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
