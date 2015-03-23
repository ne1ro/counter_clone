using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
  public AudioClip shotSound;
  public float fireRate = 1.5f; // Battle fire rate is 40 per minute for single shots
  public int cartridgeCount = 30;
  public float chargeInterval = 3.5f;
  public int distance = 1500; // Penetration distance, use 3000 for non-lethal

  private float nextFire = 0.0f;

  void Update () {
    // Shot
    if (Input.GetButton("Fire1") && Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      GetComponent<AudioSource>().PlayOneShot(shotSound);
    }
  }
}
