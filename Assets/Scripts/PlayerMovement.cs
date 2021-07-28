using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groudCheckLeft;
    public Transform groudCheckRight;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groudCheckLeft.position, groudCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetButton("Jump") && isGrounded)
        {
            isJumping = true; 
        }

        PlayerMove(horizontalMovement);     
    }

    void PlayerMove(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
