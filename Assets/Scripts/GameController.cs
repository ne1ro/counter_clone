using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
  public Text scoreText;
  private int score = 0;

  void Awake() {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.Locked;
    scoreText.text = score.ToString();
  }

  public void AddScore(int val) {
    score += val;
    scoreText.text = score.ToString();
  }
}
