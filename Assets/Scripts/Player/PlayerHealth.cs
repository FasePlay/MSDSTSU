using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //cooldowns
    public float shieldTimer = 5f;
    public float invincibilityTimer = 2f;
    
    //ui stats
    public GameObject shieldObj;
    public GameObject heart;

    //animators for hp ui
    public Animator shieldAnimator;
    public Animator playerAnimator;

    
    public GameOver gameOver;

    bool Shield = true;
    bool invincible = false;

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (invincible)
        {
            return;
        }
        else if (!collisionInfo.collider.CompareTag("Enemy"))
        {
            return;
        }
        else if (Shield)
        {
            Shield = false;
            invincible = true;
            shieldAnimator.SetBool("damaged",true);
            playerAnimator.SetTrigger("damaged");
            Invoke("ShieldInvoke", shieldTimer);
            Invoke("InvincibilityEnd", invincibilityTimer);
        }
        else
        {
            playerAnimator.SetBool("dead", true);
            gameOver.EndGame();
        }
    }
    void ShieldInvoke()
    {
        Shield = true;
        shieldAnimator.SetBool("damaged", false);
    }
    private void InvincibilityEnd()
    {
        invincible = false;
        // anims here please sanya  - /shrug
     }
}

