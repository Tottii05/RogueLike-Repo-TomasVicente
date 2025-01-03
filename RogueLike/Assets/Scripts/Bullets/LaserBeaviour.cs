using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeaviour : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform laserPosition;
    public Weapon weapon;

    public void Awake()
    {
        var player = GameObject.Find("WeaponPlace");
        if (player != null)
        {
            var playerAttack = player.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                weapon = playerAttack.weapon;
            }
        }
    }

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserPosition.position, transform.right);
        lineRenderer.SetPosition(0, laserPosition.position);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            StartCoroutine(DamagePerSecond(hit));
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 100);
        }
    }

    public IEnumerator DamagePerSecond(RaycastHit2D hit)
    {
        while (hit.collider.TryGetComponent<IDamageable>(out var damageable))
        {
            yield return new WaitForSeconds(1.2f);
            damageable.TakeDamage(weapon.damage);
        }
    }
}
