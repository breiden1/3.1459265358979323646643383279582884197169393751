using System.IO;
using UnityEngine;

public class scri : MonoBehaviour
{
    public float moveSpeed = 22f;
    Rigidbody2D rb;
    Transform target;
    SpriteRenderer sprt;

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
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //target.position.x
            //sprt.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (target)
            {
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
        }
    }
}
