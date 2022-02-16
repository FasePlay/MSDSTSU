using UnityEngine;

public class DoorSpriteSwap : MonoBehaviour
{
    //sprites for the door
    public Sprite open;
    public Sprite closed;
    public SpriteRenderer SpRender;

    //animator, DUH
    public Animator doorAnim;
    
    //collider turns off when the door is open, so we can go through
    public BoxCollider2D col;

    //initialising states
    private void Start()
    {
        SpRender.sprite = closed;
        col.enabled = true;
    }
    //called by PlayerInventory
    public void DoorOpen()
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