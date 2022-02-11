using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //inventory items
    [SerializeField] private int goldKeys = 0;
    [SerializeField] private int silverKeys = 0;
    
    //player stats
    public int playerLevel = 1;

    public void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (!collisioninfo.collider.CompareTag("goldKey"))
        {

        }
    }

}
