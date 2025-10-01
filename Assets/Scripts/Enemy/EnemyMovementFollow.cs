using UnityEngine;

public class EnemyMovementFollow : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform target;

    [SerializeField] private float stopRadius;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject player= GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            target = player.transform;
        }
    }


    private void Update()
    {
        if(target == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) <= stopRadius)
        {
            rb2d.linearVelocity = Vector2.zero;
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb2d.linearVelocity = direction * speed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
