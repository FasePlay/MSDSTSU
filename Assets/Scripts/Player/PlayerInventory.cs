using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //inventory items
    [SerializeField] private int goldKeys = 0;
    [SerializeField] private int silverKeys = 0;
    public DoorSpriteSwap DoorSpriteSwap;
    //animators and sprites for picked up stuff
    //keys 
    public Animator keyAnimator;
    //doors are in doorSpriteSwap.cs

    
    public GameObject goldKey;
    private void OnTriggerEnter2D(Collider2D col)
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
            case "doorGold":
                {
                    if (goldKeys != 0)
                    {
                        goldKeys--;
                        DoorSpriteSwap.DoorOpenAnim();
                    }
                    else print("u got no keys");
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