using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private Rigidbody2D playerRigidbody;

  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector2 movementForce = new Vector2(moveHorizontal, moveVertical);
    playerRigidbody.AddForce(movementForce * speed);
  }
}
