using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour {
  public int bulletSpeed = 715;

	void Start() {
    GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed);
	}

  void OnTriggerEnter(Collider other) {
    Debug.Log(other);
    Destroy(gameObject);
  }
}
