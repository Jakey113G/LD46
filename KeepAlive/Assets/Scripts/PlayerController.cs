using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw( "Horizontal" );
        float moveVertical = Input.GetAxisRaw( "Vertical" );

        Vector2 moveVelocity = new Vector2( moveHorizontal, moveVertical );

        if ( moveVelocity.magnitude > 1.0f )
        {
            moveVelocity = moveVelocity.normalized;
        }

        moveVelocity *= Speed;

        Vector2 velocityChange = moveVelocity - playerRigidbody.velocity;

        playerRigidbody.velocity += velocityChange * 0.8f;
    }
}