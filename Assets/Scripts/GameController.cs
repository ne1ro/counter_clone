using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  void Start() {
    // Lock cursor
    Cursor.lockState = CursorLockMode.Locked;
  }
}
