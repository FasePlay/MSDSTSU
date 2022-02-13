using UnityEngine;

public class DoorSpriteSwap : MonoBehaviour
{
    public SpriteRenderer SpRender;
    //sprites for the door
    public Sprite open;
    [SerializeField] private Sprite closed;
    
    public Animator doorAnim;
    //collider turns off when the door is open
    public BoxCollider2D col;

    //initialising states
    private void Start()
    {
        SpRender.sprite = closed;
        col.enabled = true;
    }
    //called by PlayerInventory
    public void DoorOpenAnim()
    {
        doorAnim.SetBool("isOpen", true);
        Invoke("DoorOpenSprite", 0.05f);
    }
    public void DoorOpenSprite()
    {
        SpRender.sprite = open;
        col.enabled = false;
    }
}