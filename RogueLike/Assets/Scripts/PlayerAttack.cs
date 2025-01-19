using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    public GameObject trail;
    private GameObject activeTrail;
    public bool canAttack = true;
    public AudioManager audioManager;
    public GameObject weaponSprite;

    public void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        weaponSprite = GameObject.Find("WeaponSprite");
    }

    public void Update()
    {
        trail = weapon.trail;
        if (weapon.name == "Flamethrower")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (activeTrail == null)
                {
                    activeTrail = Instantiate(trail, transform.position, transform.GetChild(0).rotation);
                    activeTrail.transform.parent = transform;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (activeTrail != null)
                {
                    Destroy(activeTrail);
                    activeTrail = null;
                }
            }
        }
        if (weapon.name == "Melee")
        {
            if (Input.GetKeyDown(KeyCode.Space) && canAttack)
            {
                Attack();
                StartCoroutine(SwordAttack());
                audioManager.PlaySFX(weapon.attackSound);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();
            audioManager.PlaySFX(weapon.attackSound);
        }
    }

    public void Attack()
    {
        canAttack = false;
        Instantiate(trail, transform.position, transform.GetChild(0).rotation);
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(weapon.attackCd);
        canAttack = true;
    }
    public IEnumerator SwordAttack()
    {
        weaponSprite.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        weaponSprite.SetActive(true);
    }

}
