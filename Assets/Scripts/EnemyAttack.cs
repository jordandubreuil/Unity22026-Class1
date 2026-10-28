using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackTransform;
    public float attackRadius;
    public float damage = 10.0f;

    public void AttackPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackTransform.position, attackRadius);

        foreach (var player in hitColliders) 
        {
            if (player.CompareTag("Player"))
            {
                player.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackTransform.position, attackRadius);
    }
}
