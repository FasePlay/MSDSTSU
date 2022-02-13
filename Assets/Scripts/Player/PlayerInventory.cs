using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //inventory items
    [SerializeField] private int goldKeys = 0;
    [SerializeField] private int silverKeys = 0;
    public int gold = 0;
    
    
    public DoorSpriteSwap DoorSpriteSwap;
    //animators and sprites for picked up stuff
    //keys 
    public Animator keyAnimator;
    public BoxCollider2D goldKeyCol;
    //coins
    [SerializeField] private Animator coinSmall;

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "goldKey":
                {
                    goldKeys++;
                    keyAnimator.SetBool("isPickedUp", true);
                    goldKeyCol.enabled = false;
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
            case "coinSmall":
                {
                    gold++;
                    coinSmall.SetBool("isCollected", true);
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