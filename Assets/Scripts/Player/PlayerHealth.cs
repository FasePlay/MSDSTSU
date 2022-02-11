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
    bool invincible;

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (!invincible)
        {
            if (collisionInfo.gameObject.tag == "Enemy")
            {

                if (Shield)
                {
                    shieldAnimator.SetBool("damaged", true);
                    playerAnimator.SetTrigger("damaged");
                    Shield = false;
                    invincible = true;
                    Invoke("ShieldInvoke", shieldTimer);
                    Invoke("DisableInvincibility", invincibilityTimer);
                    heart.GetComponent<RawImage>().enabled = true;
                }
                else
                {
                    playerAnimator.SetBool("dead", true);
                    gameOver.EndGame();
                }
            }
        }
    }

    private void ShieldInvoke()
    {
        Shield = true;
        shieldAnimator.SetBool("damaged", false);
    }

    private void DisableInvincibility()
    {
        invincible = false;
    }
}

