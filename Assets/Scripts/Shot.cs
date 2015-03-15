using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
  public AudioSource shotSound;
  public float fireRate = 0.1f;

  private float nextFire = 0.0f;

  void Update () {
    // Shot
    if (Input.GetButton("Fire1") && Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      shotSound.Play();
    }
  }
}
