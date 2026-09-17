using UnityEngine;
using UnityEngine.InputSystem;

public class scr : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight;
    public Rigidbody2D rb2d;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        float input = ctx.ReadValue<Vector2>().x;
        movement.x = input * speed;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
        rb2d.linearVelocityY = jumpHeight;

        }
    }
}
