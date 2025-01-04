using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeaponSprite : MonoBehaviour
{
    public Weapon weapon;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        weapon = GameObject.Find("WeaponPlace").GetComponent<PlayerAttack>().weapon;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = weapon.weaponSprite;
    }
}
