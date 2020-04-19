using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;

    private string previousAnimationTrigger = "Idle";
    private float originalXScale;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        originalXScale = transform.localScale.x;
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

            transform.localScale = new Vector3( animationTrigger == "WalkLeft" ? originalXScale : -originalXScale, transform.localScale.y, transform.localScale.z );
        }
    }

    private string GetAnimationTrigger()
    {
        Vector2 velocity = playerRigidbody.velocity;

        if ( velocity.magnitude <= 0.2f )
        {
            return "Idle";
        }

        if ( Mathf.Abs( velocity.x ) > 0.2 )
        {
            return velocity.x > 0 ? "WalkRight" : "WalkLeft";
        }

        return velocity.y > 0.2 ? "WalkBack" : "WalkFront";
    }
}