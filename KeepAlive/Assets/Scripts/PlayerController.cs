using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;

  private Rigidbody2D playerRigidbody;

  private Vector2 currentVelocity;

  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody2D>();
    currentVelocity = new Vector2(0, 0);
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector2 moveVelocity = new Vector2(moveHorizontal, moveVertical);

    if(moveVelocity.magnitude > 1.0f) moveVelocity = moveVelocity.normalized;
    moveVelocity *= speed;

    Vector2 velocityChange = moveVelocity - playerRigidbody.velocity;

    playerRigidbody.velocity += velocityChange * 0.8f;
  }
}
