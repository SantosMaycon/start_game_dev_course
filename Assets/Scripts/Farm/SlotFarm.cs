using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour {
  [SerializeField] private Sprite hole;
  [SerializeField] private Sprite carrot;
  [SerializeField] private int digAmount;
  private int initialDig;

  private SpriteRenderer spriteRenderer;
  
  // Start is called before the first frame update
  void Start() {
    spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    initialDig = digAmount;
  }

  // Update is called once per frame
  void Update() {}

  public void OnHit() {
    digAmount--;

    if (digAmount <= initialDig / 2) {
      spriteRenderer.sprite = hole;
    }

    if (digAmount <= 0) {
      // TODO: ADD CARROT
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Dig")) {
      OnHit();
    }
  }
}
