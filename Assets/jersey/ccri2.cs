using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ccri2 : MonoBehaviour
{
    public float moveSpeed = 22f;

    public GameObject player;

    public float attackDistanceThreshold = 8f;
    public float maxAttackDistanceThreshold = 15f;

    public float damage = 3f;

    public float totalCooldownTime = 2.0f;
    private float currentCooldownTime = 0.0f;

    private Rigidbody2D rb;
    private SpriteRenderer sprt;
    private Transform target;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            GameObject playerObject = GameObject.Find("main-man_0");

            if (playerObject != null)
            {
                player = playerObject;
                target = playerObject.transform;
            }
        }
    }

    private void Update()
    {
        if (player == null || target == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            player.transform.position
        );

        if (distance < maxAttackDistanceThreshold)
        {
            // Chase the player
            if (distance > attackDistanceThreshold)
            {
                Vector3 direction =
                    (target.position - transform.position).normalized;

                moveDirection = direction;

                // Move horizontally only
                rb.linearVelocity = new Vector2(
                    moveDirection.x * moveSpeed,
                    rb.linearVelocity.y
                );
            }
            else
            {
                // Stop when close enough to attack
                rb.linearVelocity = new Vector2(
                    0f,
                    rb.linearVelocity.y
                );

                // Attack
                if (currentCooldownTime <= 0f)
                {
                    Health playerHealth = player.GetComponent<Health>();

                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damage);
                    }

                    currentCooldownTime = totalCooldownTime;

                    Debug.Log("Enemy attacked player for " + damage + " damage.");
                }
            }

            currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = new Vector2(
                0f,
                rb.linearVelocity.y
            );
        }
    }
}