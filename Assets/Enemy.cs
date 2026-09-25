using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 3f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        StopAllCoroutines();
        StartCoroutine(HitAnimation());

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator HitAnimation()
    {
        animator.SetBool("die", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("die", false);
    }
}