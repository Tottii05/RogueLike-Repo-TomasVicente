using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int attackCd = 2;
    public GameObject enemy;
    private Stack<GameObject> stack;
    public bool canShoot = false;
    public int attackRadius = 4;

    void Start()
    {
        stack = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, enemy.transform.position, Quaternion.identity);
            bullet.SetActive(false);
            stack.Push(bullet);
        }
        StartCoroutine(Shoot());
    }

    public void Update()
    {
        if (Vector2.Distance(transform.position, enemy.transform.position) < attackRadius)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    private IEnumerator Shoot()
    {
        if (canShoot && stack.Count > 0)
        {
            GameObject bullet = Pop();
            bullet.transform.position = enemy.transform.position;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(attackCd);
        yield return Shoot();
    }

    public void Push(GameObject bullet)
    {
        bullet.SetActive(false);
        stack.Push(bullet);
    }

    public GameObject Pop()
    {
        return stack.Pop();
    }
}
