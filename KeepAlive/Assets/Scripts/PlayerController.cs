using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;

    private string previousAnimationTrigger = "Idle";

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
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

    private void LateUpdate()
    {
        string animationTrigger = GetAnimationTrigger();

        if ( animationTrigger != previousAnimationTrigger )
        {
            previousAnimationTrigger = animationTrigger;
            playerAnimator.SetTrigger( previousAnimationTrigger );
        }
    }

    private string GetAnimationTrigger()
    {
        return playerRigidbody.velocity.magnitude <= 0.1f ? "Idle" : "WalkFront";
    }
}