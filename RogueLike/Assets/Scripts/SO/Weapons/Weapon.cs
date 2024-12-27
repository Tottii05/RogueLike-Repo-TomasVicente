using UnityEngine;

[CreateAssetMenu(fileName = "Weapons.asset", menuName = "Weapons/Weapon")]

public class Weapon : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public GameObject trail;
    public int damage;
    public float attackCd;
}
