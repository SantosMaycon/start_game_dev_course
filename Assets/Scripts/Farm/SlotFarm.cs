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
  
  [Header("SFX")]
  [SerializeField] private AudioClip holeSound;
  [SerializeField] private AudioClip carrotSound;
  private AudioSource audioSource;
  private bool detecting;
  private bool detectingPlayer;
  private float currentWater;
  private PlayerItems items;

  private SpriteRenderer spriteRenderer;

  private bool isHole;

  // Start is called before the first frame update
  void Start() {
    items = FindObjectOfType<PlayerItems>();
    spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update() {
    if (digAmount <= 0) {
      if (detecting) {
        currentWater += 0.01f;
      }

      if (currentWater >= waterAmount && detectingPlayer && !isHole) {
        audioSource.PlayOneShot(holeSound);
        spriteRenderer.sprite = carrot;
        isHole = true;
      }

      if (Input.GetKeyDown(KeyCode.E) && detectingPlayer) {
        audioSource.PlayOneShot(carrotSound);
        spriteRenderer.sprite = hole;
        items.carrots++;
        currentWater = 0f;
        isHole = false;
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
