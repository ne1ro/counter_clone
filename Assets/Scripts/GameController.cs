using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  void Start() {
    // Lock and hide cursor
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }
}
