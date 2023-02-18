using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
  [SerializeField] private bool detectingPlayer;
  [SerializeField] private float waterValue;
  private PlayerItems items;

  // Start is called before the first frame update
  void Start() {
    items = FindObjectOfType<PlayerItems>();
  }

  // Update is called once per frame
  void Update() {
    if (detectingPlayer && Input.GetKeyDown(KeyCode.E)) {
      items.SetWater(waterValue);
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      detectingPlayer = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      detectingPlayer = false;
    }
  }
}
