using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  void Awake() {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.Locked;
  }
}
