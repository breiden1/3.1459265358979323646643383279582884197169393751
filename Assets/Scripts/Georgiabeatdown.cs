using UnityEngine;
using UnityEngine.InputSystem;

public class Geogiabeatdown : MonoBehaviour
{
    public float attackRange = 2f;
    public float damage = 1f;
    public float attackCooldown = 0.5f;

    private float cooldown;

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || cooldown > 0)
        {
            return;
        }

        cooldown = attackCooldown;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(damage);
                }

                break;
            }
        }
    }
}