using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
  private float startTime;

  void Awake() {
    startTime = Time.time;
  }

  void Update() {
    float elapsedTime = Time.time - startTime;
    GetComponent<Text>().text = elapsedTime.ToString();
  }
}
