using System.Collections;
using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    public float stoppingDistance = 0.25f;
    public Vector2 targetPosition;
    public bool startChase = false;
    public Animator animator;
    public int explosionRadius = 1;
    public int explosionDamage = 20;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        if (startChase && target != null && target.GetComponent<PlayerHp>().Hp > 0)
        {
            targetPosition = target.transform.position;
            Chase();
        }
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Explosion());
        }
    }

    public IEnumerator Explosion()
    {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(0.34f);
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var collider in objectsInRange)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHp>().TakeDamage(explosionDamage);
            }
        }
        GetComponent<HPSystem>().TakeDamage(100);
    }
}
