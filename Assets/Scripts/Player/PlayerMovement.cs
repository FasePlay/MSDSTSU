using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [SerializeField] private float speed = 5f; //скорость передвижения
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    // Animation
    [SerializeField] private Animator animator;
    public bool isWalking = false;

    // Dashing
    // private bool isDashing = false;
    // [SerializeField] private float DashCooldown = 3.5f;
    // public float NextDashIn = 0;
    // [SerializeField] private Transform cam;
    // [SerializeField] float dashSpeed = 10.0f;
    void FixedUpdate()
    {
        // Dash();
        MovePlayer();
        AnimatePlayerMovement();
    }

    void AnimatePlayerMovement()
    {
        // Animation
        if (Input.GetAxisRaw("Horizontal") != 0) //if we are moving horizontally
            animator.SetBool("isWalking", true); //enable animation
        else
            animator.SetBool("isWalking", false); //disable animation
        // Rotation
        if (Input.mousePosition.x < rb.position.x + (Screen.width / 2)) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }

    void MovePlayer()
    {
        // Getting  player's movement axises
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); // Actually moving player
    }
    // private void Dash()
    // {
    //     if (Input.GetKeyDown(KeyCode.LeftShift)) //&& NextDashIn <= Time.time)
    //     {
    //         Vector2.MoveTowards(transform.position, cam.position, dashSpeed*Time.deltaTime);
    //         //NextDashIn = Time.time + DashCooldown;
    //         print($"next dash: {NextDashIn}, time: {Time.time}");
    //     }
    // }
}