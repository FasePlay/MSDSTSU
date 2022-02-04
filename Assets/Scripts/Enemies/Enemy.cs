using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, Vector3 playerPosition)
    {
        currentHealth -= damage;
        animator.SetTrigger("damaged");

        this.GetComponent<Rigidbody2D>().AddForce((transform.position - playerPosition).normalized * 10);
        Debug.Log(transform.position - playerPosition);


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

        Debug.Log("Enemy died");
        animator.SetBool("dead", true);
        GetComponent<Collider2D>().enabled = false;
        enabled = false;

        Destroy(gameObject, 0.3f);  
    }
}
