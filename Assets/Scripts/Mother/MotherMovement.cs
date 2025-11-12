using System.Collections;
using UnityEngine;

public class MotherMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;

    private bool isAttacking;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isAttacking)
        {
            rb2d.linearVelocity = Vector2.zero;
            return;
        }

        if(target==null)
        {
            rb2d.linearVelocity = Vector2.zero;
            return;
        }
        
        if(Vector2.Distance(transform.position, target.position) <= stopDistance)
        {
            StartCoroutine(Attack());
            rb2d.linearVelocity= Vector2.zero;
            return;
        }

        Vector2 direction= (target.position - transform.position).normalized;
        rb2d.linearVelocity= direction * speed;
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(2);
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
