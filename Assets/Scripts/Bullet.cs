using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
  public int bulletSpeed = 715;

	void Start() {
    GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed);
	}

  void OnTriggerEnter(Collider other) {
    Destroy(gameObject);
  }
}
