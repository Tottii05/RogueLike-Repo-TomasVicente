using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour, IDamageable
{
    public GameObject target;
    public float speed = 5f;
    public float stoppingDistance = 0.25f;
    public Vector2 targetPosition;
    public bool startChase = false;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        targetPosition = target.transform.position;
        Chase();
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, targetPosition) > stoppingDistance && startChase)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
