using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, Vector3 playerPosition)
    {
        currentHealth -= damage;
        animator.SetTrigger("damaged");

        this.GetComponent<Rigidbody2D>().AddForce((transform.position - playerPosition).normalized * 10);
        print(transform.position - playerPosition);


        // hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Die animation

        // DIsable enemy

        print("Enemy died");
        animator.SetBool("dead", true);
        GetComponent<Collider2D>().enabled = false;
        enabled = false;

        Destroy(gameObject, 0.3f);  
    }
}
