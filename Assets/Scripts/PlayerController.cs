using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float speed = 7.0f;
  public float jumpSpeed = 3.75f;
  public float gravity = 9.81f;
  public AudioClip jumpSound;

  private Vector3 moveDirection = Vector3.zero;

  void Update() {
    CharacterController controller = GetComponent<CharacterController>();

    // Move player character
    if (controller.isGrounded) {
      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      moveDirection = transform.TransformDirection(moveDirection);
      moveDirection *= speed;

      // Jump and play jump sound
      if (Input.GetButton("Jump")) {
        moveDirection.y = jumpSpeed;
        GetComponent<AudioSource>().PlayOneShot(jumpSound);
      }
    }

    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
  }
}
