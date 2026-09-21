using UnityEngine;
using UnityEngine.InputSystem;

public class Geogiabeatdown : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public LayerMask attackLayer;
    void Start()
    {

    }



    void Update()
    {

    }



    public void Attack(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, attackRadius, Vector2.zero, 0, attackLayer);

        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
