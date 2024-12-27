using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    public GameObject trail;
    private bool canAttack = true;

    public void Start()
    {
        trail = weapon.trail;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();
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
}
