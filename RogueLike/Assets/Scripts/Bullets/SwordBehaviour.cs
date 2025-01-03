using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator Attack()
    {
        animator.SetTrigger("Attacking");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
