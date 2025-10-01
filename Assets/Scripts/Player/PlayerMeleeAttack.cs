using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float radius;
    [SerializeField] private Transform attackPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(attackPoint == null)
        {
            return;
        }

        Collider2D[] hits=Physics2D.OverlapCircleAll(attackPoint.position, radius, enemyLayerMask);

        foreach(Collider2D hit in hits)
        {
            Destroy(hit.gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

}
