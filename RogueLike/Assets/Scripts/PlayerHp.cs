using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour, IDamageable
{
    public int Hp = 100;

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            StartCoroutine(DeathCoroutine());
        }
    }

    public IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
