using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
  public float turnSpeed = 4.0f;
  public float panSpeed = 4.0f;
  public GameObject player;

  private Vector3 mouseOrigin;
  private bool isRotating;

  void Update() {
    // Get the left mouse button
    if(Input.GetMouseButtonDown(1)) {
      // Get mouse origin
      mouseOrigin = Input.mousePosition;
      isRotating = true;
    }

    // Reset isRotating on mouse down
    if (!Input.GetMouseButton(1)) isRotating = false;

    // Rotate camera along X and Y axis
    if (isRotating) {
      Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

      transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
      player.transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
    }
  }
}
