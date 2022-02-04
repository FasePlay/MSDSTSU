using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Vector3 offset;
    private Vector3 mousePosition;

    void Update()
    {
        mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.position = new Vector3((4 * player.position.x +mousePosition.x)/5 + offset.x, (4 * player.position.y + mousePosition.y)/5 + offset.y,offset.z);
        
    }
}
