using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    public GameObject trail;
    private GameObject activeTrail;
    public bool canAttack = true;

    public void Awake()
    {
        trail = weapon.trail;
    }

    public void Update()
    {
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
        else if (Input.GetKeyDown(KeyCode.Space) && canAttack)
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
