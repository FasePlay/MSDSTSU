using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //inventory items
    [SerializeField] private int goldKeys = 0;
    [SerializeField] private int silverKeys = 0;
    public Animator keyAnimator;
    public GameObject goldKey;
    public int playerInput = 1;

    //player stats
    public int playerLevel = 1;

    public void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "goldKey":
                {
                    goldKeys++;
                    keyAnimator.SetBool("isPickedUp", true);
                    goldKey.GetComponent<BoxCollider2D>().enabled = false;
                    break;
                }
            case "silverKey":
                {
                    silverKeys++;
                    break;
                }
            default:
                {
                    print("tf did u collide with?");
                    break;
                }
        }
        print($"u got {goldKeys} gold keys");
    }
}