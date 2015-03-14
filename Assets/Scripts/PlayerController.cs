using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public Transform lookTransform;
  public Vector3 gravity = Vector3.down * 9.81f; // custom gravity
  public float rotationRate = 0.1f;
	public float velocity = 8;
	public float groundControl = 1.0f;
	public float airControl = 0.2f;
	public float jumpVelocity = 5;
	public float groundHeight = 1.1f;
	private bool jump;

  // Set custom gravity on start
  void Start() {
    GetComponent<Rigidbody>().freezeRotation = true;
    GetComponent<Rigidbody>().useGravity = true;
  }

  // Jump update
  void Update() {
    jump = jump || Input.GetButtonDown("Jump");
  }

  void FixedUpdate() {
    // Cast a ray towards the ground to see if the Walker is grounded
    bool grounded = Physics.Raycast(transform.position, gravity.normalized,
      groundHeight);

    // Rotate the body to stay upright
    Vector3 gravityForward = Vector3.Cross(gravity, transform.right);
    Quaternion targetRotation = Quaternion.LookRotation(gravityForward, -gravity);
    GetComponent<Rigidbody>().rotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation,
      rotationRate);

    // Add velocity change for movement on the local horizontal plane
    Vector3 forward = Vector3.Cross(transform.up, -lookTransform.right).normalized;
    Vector3 right = Vector3.Cross(transform.up, lookTransform.forward).normalized;
    Vector3 targetVelocity = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * velocity;
    Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
    Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity) - localVelocity;

    // The velocity change is clamped to the control velocity
    // The vertical component is either removed or set to result in the absolute jump velocity
    velocityChange = Vector3.ClampMagnitude(velocityChange, grounded ? groundControl : airControl);
    velocityChange.y = jump && grounded ? -localVelocity.y + jumpVelocity : 0;
    velocityChange = transform.TransformDirection(velocityChange);
    GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

    // Add gravity
    GetComponent<Rigidbody>().AddForce(gravity * GetComponent<Rigidbody>().mass);

    // Turn off jump
    jump = false;
  }
}
