using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 9f;
    public float currentHealth;
    public Animator animator;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hit");
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}