using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  void Awake() {
    // Lock and hide cursor
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }
}
