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
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stack = new Stack<GameObject>();
        animator = GetComponent<Animator>();

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
        if (player != null)
        {
            FlipSpriteTowardsPlayer();
        }

        if (canShoot && stack.Count > 0 && !isShooting && IsPlayerAlive())
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        animator.SetTrigger("Attack");
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

    public void FlipSprite()
    {
        Vector3 scale = shooterPrefab.transform.localScale;
        scale.x *= -1;
        shooterPrefab.transform.localScale = scale;
    }

    private void FlipSpriteTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - shooterPrefab.transform.position;
            if (direction.x > 0 && shooterPrefab.transform.localScale.x < 0)
            {
                FlipSprite();
            }
            else if (direction.x < 0 && shooterPrefab.transform.localScale.x > 0)
            {
                FlipSprite();
            }
        }
    }
}
