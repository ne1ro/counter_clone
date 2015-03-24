using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float speed = 7.0f;
  public float jumpSpeed = 3.75f;
  public float gravity = 9.81f;
  public AudioClip jumpSound;
  public AudioClip runningSound;

  private Vector3 moveDirection = Vector3.zero;

  void Update() {
    CharacterController controller = GetComponent<CharacterController>();
    AudioSource audio = GetComponent<AudioSource>();

    // Move player character
    if (controller.isGrounded) {
      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      moveDirection = transform.TransformDirection(moveDirection);
      moveDirection *= speed;

      // Jump and play jump sound
      if (Input.GetButton("Jump")) {
        moveDirection.y = jumpSpeed;
        if (audio.isPlaying) audio.Stop();
        audio.PlayOneShot(jumpSound);
      }

      // Running sound
      if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) {
        if (!audio.isPlaying) {
          audio.clip = runningSound;
          audio.Play();
        } else {
          if (audio.isPlaying) audio.Stop();
        }
      }

      if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")) {
        if (audio.clip == runningSound && audio.isPlaying) audio.Stop();
      }
    }

    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
  }
}
