using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
  public AudioClip shotSound;
  public float fireRate = 0.1f;

  private float nextFire = 0.0f;

  void Update () {
    // Shot
    if (Input.GetButton("Fire1") && Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      GetComponent<AudioSource>().PlayOneShot(shotSound);
    }
  }
}
