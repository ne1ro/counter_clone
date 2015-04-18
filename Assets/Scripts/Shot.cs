using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shot : MonoBehaviour {
  public float fireRate = 1.5f; // Battle fire rate is 40 per minute for single shots
  public int cartridgeCount = 30;
  public int distance = 400;
  public float chargeInterval = 3.5f;

  public AudioClip shotSound;
  public AudioClip chargeSound;
  public Text roundCountText;

  private float nextFire;
  private int roundCount;

  private GameController gameController;

  void Start() {
    nextFire = 0.0f;
    roundCount = cartridgeCount;
    roundCountText.text = roundCount.ToString();

    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
    gameController = gameControllerObject.GetComponent<GameController>();
  }

  void Update() {
    // Shot
    if (Input.GetButton("Fire1") && Time.time > nextFire && roundCount > 0) {
      nextFire = Time.time + fireRate;
      roundCount --;
      roundCountText.text = roundCount.ToString();
      GetComponent<AudioSource>().PlayOneShot(shotSound);

      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hit, distance)) {
        GameObject collided = hit.collider.gameObject;

        Debug.Log(collided.tag);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        // Check for collision
        if (collided.tag == "Mob") {
          Destroy(collided);
          gameController.AddScore(500);
        }
      }

      if (roundCount <= 0) StartCoroutine(Recharge());
    }
  }

  // Recharge weapon
  private IEnumerator Recharge() {
    Animation animation = GetComponent<Animation>();

    Cursor.visible = false;
    animation.Play();
    GetComponent<AudioSource>().PlayOneShot(chargeSound);

    yield return new WaitForSeconds(chargeInterval);

    animation.Stop();
    roundCount = cartridgeCount;
    Cursor.visible = true;
  }
}
