using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {
  private float startTime;

  void Awake() {
    startTime = Time.time;
  }

  void Update() {
    TimeSpan t = TimeSpan.FromSeconds(Time.time - startTime);
    GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}", t.Minutes,
      t.Seconds);
  }
}
