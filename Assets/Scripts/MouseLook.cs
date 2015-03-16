using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
  public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
  public RotationAxes axes = RotationAxes.MouseXAndY;

  public float sensitivityX = 2.5f;
  public float sensitivityY = 2.5f;

  public float minimumX = -360f;
  public float maximumX = 360f;

  public float minimumY = -60f;
  public float maximumY = 60f;

  private float rotationY = 0f;

  void Update () {
    // Move camera on X and Y mouse move
    if (axes == RotationAxes.MouseXAndY) {
      float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X")
        * sensitivityX;

      rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
      rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

      transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    // Move camera on X mouse move
    else if (axes == RotationAxes.MouseX) {
      transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
    }
    // Move camera on Y mouse move
    else {
      rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
      rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

      transform.localEulerAngles = new Vector3(-rotationY,
        transform.localEulerAngles.y, 0);
    }
  }
}
