using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeaponSprite : MonoBehaviour
{
    public Weapon weapon;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        weapon = GetComponentInParent<PlayerAttack>().weapon;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = weapon.weaponSprite;
    }
}
