using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int attackCd = 3;
    public GameObject shooterPrefab;
    private Stack<GameObject> stack;
    public bool canShoot = false;
    public int attackRadius = 7;
    private GameObject player;
    private bool isShooting = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stack = new Stack<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, shooterPrefab.transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyTrailBehaviour>().enemy = shooterPrefab;
            bullet.SetActive(false);
            stack.Push(bullet);
        }
    }

    void Update()
    {
        if (canShoot && stack.Count > 0 && !isShooting && IsPlayerAlive())
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject bullet = Pop();

        bullet.SetActive(true);

        Vector3 targetPosition = player.transform.position;

        bullet.transform.position = shooterPrefab.transform.position;
        bullet.GetComponent<EnemyTrailBehaviour>().SetDirection(targetPosition);

        yield return new WaitForSeconds(attackCd);
        isShooting = false;
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

    private bool IsPlayerAlive()
    {
        if (player == null)
        {
            return false;
        }

        PlayerHp playerHealth = player.GetComponent<PlayerHp>();
        if (playerHealth != null && playerHealth.Hp > 0)
        {
            return true;
        }

        return false;
    }
}
