using UnityEngine;

public class DoorSpriteSwap : MonoBehaviour
{
    public SpriteRenderer SpRender;
    public Sprite open;
    [SerializeField] private Sprite closed;
    public Animator doorAnim;

    private void Start()
    {
        SpRender.sprite = closed;
    }
    public void DoorOpenAnim()
    {
        doorAnim.SetBool("isOpen", true);
        Invoke("DoorOpenSprite", 0.05f);
    }
    public void DoorOpenSprite()
    {
        SpRender.sprite = open;
    }
}