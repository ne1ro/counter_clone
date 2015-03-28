using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shot : MonoBehaviour {
  public float fireRate = 1.5f; // Battle fire rate is 40 per minute for single shots
  public int cartridgeCount = 30;
  public float chargeInterval = 3.5f;
  public int distance = 1500; // Lethal distance
  public int bulletSpeed = 715; // Bullet speed

  public AudioClip shotSound;
  public AudioClip chargeSound;
  public Text roundCountText;

  private float nextFire;
  private float acceleration;
  private int roundCount;

  void Start() {
    nextFire = 0.0f;
    roundCount = cartridgeCount;
    roundCountText.text = roundCount.ToString();
    acceleration = bulletSpeed * bulletSpeed / 2 * distance;
  }

  void Update() {
    // Shot
    if (Input.GetButton("Fire1") && Time.time > nextFire && roundCount > 0) {
      nextFire = Time.time + fireRate;
      roundCount --;
      roundCountText.text = roundCount.ToString();
      GetComponent<AudioSource>().PlayOneShot(shotSound);

      if (roundCount <= 0) StartCoroutine(Recharge());
    }
  }

  // Recharge weapon
  private IEnumerator Recharge() {
    GetComponent<AudioSource>().PlayOneShot(chargeSound);
    yield return new WaitForSeconds(chargeInterval);
    roundCount = cartridgeCount;
  }
}
