using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ccri2 : MonoBehaviour
{
    public float moveSpeed = 22f;
    public float playerHp = 9f;
    Rigidbody2D rb;
    Transform target;
    SpriteRenderer sprt;
    public GameObject player;
    public float attackDistanceThreshold = 8f;
    public float maxAttackDistanceThreshold = 15f;
    private bool isGrounded;
    public float totalCooldownTime = 2.0f;
    private float currentCooldownTime = 0.0f;

    public Animator animator;
    Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("main-man_0").transform;
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 playerpos = player.transform.position;
        Vector2 mypos = transform.position;
        float distance = Vector2.Distance(mypos, playerpos);
        if (distance < maxAttackDistanceThreshold)
        {
            if (distance > attackDistanceThreshold)
            {
                if (target)
                {
                    Vector3 direction = (target.position - transform.position).normalized;
                    moveDirection = direction;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    //target.position.x
                    //sprt.flipX = true;
                    rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y - moveDirection.y) * moveSpeed;

                }
            }

            if (distance < attackDistanceThreshold)
            {
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * 0;
            }
            if (distance < attackDistanceThreshold && currentCooldownTime <= 0.0f)
            {
                animator.SetBool("attack", true);
                float v = playerHp -= 3;
                currentCooldownTime = totalCooldownTime;
                Debug.Log("ow");
                
            }
            if (currentCooldownTime <= 0f)
            {
                animator.SetBool("attack", false);
                Debug.Log("unow");
            }
            if (playerHp <= 0)
            {
                Destroy(player);

            }

            currentCooldownTime -= Time.deltaTime;
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