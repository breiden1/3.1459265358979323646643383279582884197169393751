using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class scri : MonoBehaviour
{
    public float moveSpeed = 22f;
    Rigidbody2D rb;
    Transform target;
    SpriteRenderer sprt;
    public GameObject player;
    public float attackDistanceThreshold = 0f;
    private bool isGrounded;

    Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        target = GameObject.Find("main-man_0").transform;
    }

    // Update is called once per frame
    void Update()
    {
    
        Vector2 playerpos = player.transform.position;
        Vector2 mypos = transform.position;
        float distance = Vector2.Distance(mypos, playerpos);

        if (distance > attackDistanceThreshold) {
            if (target)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                //target.position.x
                //sprt.flipX = true;
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
        }
        if (distance < attackDistanceThreshold)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * 0;
        }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
