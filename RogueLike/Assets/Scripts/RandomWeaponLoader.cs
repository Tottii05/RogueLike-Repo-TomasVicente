using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomWeaponLoader : MonoBehaviour
{
    public Weapon[] weapons;
    public Weapon choosedWeapon;
    public SpriteRenderer weaponSpriteRenderer;
    public TextMeshProUGUI shopItemText;
    void Start()
    {
        LoadRandomWeapon();
    }

    public void LoadRandomWeapon()
    {
        choosedWeapon = weapons[Random.Range(0, weapons.Length)];
        weaponSpriteRenderer.sprite = choosedWeapon.weaponSprite;
        shopItemText.text = choosedWeapon.price.ToString();
    }
}
