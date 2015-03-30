using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyByCollision : MonoBehaviour {
  public int bulletSpeed = 715;
  private GameController gameController;

	void Start() {
    GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed);

    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
    gameController = gameControllerObject.GetComponent<GameController>();
	}

  void Update() {
    Vector3 forward = transform.TransformDirection(Vector3.forward) * 7;
    Debug.DrawRay(transform.position, forward, Color.red);
  }

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Mob") {
      Destroy(other.gameObject);
      gameController.AddScore(500);
    }
    if (other.tag != "Boundary") {
      Destroy(gameObject);
    }
  }
}
