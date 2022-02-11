using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float shieldTimer = 5f;
    public float invincibilityTimer = 2f;
    public GameObject shieldObj;
    public GameObject heart;

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
            Invoke("invincible = false;", invincibilityTimer);
        }
        else
        {
            playerAnimator.SetBool("dead", true);
            gameOver.EndGame();
        }

    }
    private void ShieldInvoke()
    {
        Shield = true;
        shieldAnimator.SetBool("damaged", false);
    }
}

