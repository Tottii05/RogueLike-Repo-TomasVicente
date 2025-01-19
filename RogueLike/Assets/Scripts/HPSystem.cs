using System;
using UnityEngine;

public class HPSystem : MonoBehaviour, IDamageable
{
    public int Hp = 100;
    public static event Action OnEnemyKilled;

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            if (GetComponent<BoxCollider2D>() != null)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            OnEnemyKilled?.Invoke();
            GetComponent<IDroppeable>().Drop();

            this.enabled = false;

            Destroy(gameObject);
        }
    }
}
