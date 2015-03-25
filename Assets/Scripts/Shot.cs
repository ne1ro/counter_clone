using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shot : MonoBehaviour {
  public float fireRate = 1.5f; // Battle fire rate is 40 per minute for single shots
  public int cartridgeCount = 30;
  public float chargeInterval = 3.5f;
  public int distance = 1500; // Penetration distance, use 3000 for non-lethal

  public AudioClip shotSound;
  public AudioClip chargeSound;
  public Text roundCountText;


  private float nextFire;
  private int roundCount;

  void Start() {
    nextFire = 0.0f;
    roundCount = 5;
    roundCountText.text = roundCount.ToString();
  }

  void Update() {
    bool isCharged = roundCount > 0;
    // Shot
    if (Input.GetButton("Fire1") && Time.time > nextFire && isCharged) {
      nextFire = Time.time + fireRate;
      roundCount --;
      roundCountText.text = roundCount.ToString();
      GetComponent<AudioSource>().PlayOneShot(shotSound);
    }

    // Recharge
    if (roundCount <= 0) {
      roundCount = cartridgeCount;
    }
  }
}
