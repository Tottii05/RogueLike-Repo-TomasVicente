using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeaponSprite : MonoBehaviour
{
    public Weapon weapon;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        weapon = GameObject.Find("WeaponPlace").GetComponent<PlayerAttack>().weapon;
        spriteRenderer.sprite = weapon.weaponSprite;
    }
}
