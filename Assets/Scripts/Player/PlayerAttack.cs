using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator swordAnimator;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 15;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            if (!swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("swordAttack"))
            {
                Attack();
            }
            
        }
    }


    void Attack()
    {
        // animate
        swordAnimator.SetTrigger("Attack");
        GameObject.FindGameObjectWithTag("Sword").GetComponent<TrailRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Trail Point").GetComponent<TrailRenderer>().enabled = true;
        Invoke("DisableTrails", 1.5f);

        // detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage, transform.position);
        }

    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void DisableTrails()
    {
        GameObject.FindGameObjectWithTag("Sword").GetComponent<TrailRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Trail Point").GetComponent<TrailRenderer>().enabled = false;
    }
}
