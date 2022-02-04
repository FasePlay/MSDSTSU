using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator swordAnimator;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;

    public int attackDamage = 15;

    // Update is called once per frame
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
}
