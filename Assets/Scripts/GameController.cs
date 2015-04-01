using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
  public Text scoreText;
  private int score = 0;

  void Awake() {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    scoreText.text = score.ToString();
  }

  public void AddScore(int val) {
    score += val;
    scoreText.text = score.ToString();
  }
}
