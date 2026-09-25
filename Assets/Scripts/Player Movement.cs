using UnityEngine;
using UnityEngine.InputSystem;

public class scr : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;

    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector2 movement;
    private bool grounded;

    private void Update()
    {
        transform.Translate(movement * Time.deltaTime);

        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        float input = ctx.ReadValue<Vector2>().x;
        movement.x = input * speed;

        if (input != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && grounded)
        {
            rb2d.linearVelocityY = jumpHeight;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}