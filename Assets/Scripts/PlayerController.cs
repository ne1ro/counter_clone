using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float speed = 6.0F;
  public float jumpSpeed = 8.0F;
  public float gravity = 9.81F;

  private Vector3 moveDirection = Vector3.zero;

  void Update() {
    CharacterController controller = GetComponent<CharacterController>();

    // Move player character
    if (controller.isGrounded) {
      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      moveDirection = transform.TransformDirection(moveDirection);
      moveDirection *= speed;

      if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
    }

    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
  }
}
