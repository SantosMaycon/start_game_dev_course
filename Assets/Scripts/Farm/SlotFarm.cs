using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour {
  [Header("Components")]
  [SerializeField] private Sprite hole;
  [SerializeField] private Sprite carrot;
  
  [Header("Settings")]
  [SerializeField] private int digAmount; // Quantidade de cavadas para aparecer o buraco
  [SerializeField] private float waterAmount; // Quantidade de agua para aparecer a cenoura
  private bool detecting;
  private bool detectingPlayer;
  private float currentWater;
  private PlayerItems items;

  private SpriteRenderer spriteRenderer;
  
  // Start is called before the first frame update
  void Start() {
    items = FindObjectOfType<PlayerItems>();
    spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update() {
    if (digAmount <= 0) {
      if (detecting) {
        currentWater += 0.01f;
      }

      if (currentWater >= waterAmount && detectingPlayer) {
        spriteRenderer.sprite = carrot;

        if (Input.GetKeyDown(KeyCode.E)) {
          spriteRenderer.sprite = hole;
          items.carrots++;
          currentWater = 0f;
        }
      }
    }
  }

  public void OnHit() {
    digAmount--;

    if (digAmount <= 0) {
      spriteRenderer.sprite = hole;
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Dig")) {
      OnHit();
    }

    if (other.CompareTag("Water")) {
      detecting = true;
    }

    if (other.CompareTag("Player")) {
      detectingPlayer = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Water")) {
      detecting = false;
    }

    if (other.CompareTag("Player")) {
      detectingPlayer = false;
    }
  }
}
