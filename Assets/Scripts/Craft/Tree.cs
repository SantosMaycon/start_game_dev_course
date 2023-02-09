using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
  [SerializeField] private float health;
  private Animator animator;
  // Start is called before the first frame update
  void Start() {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {}

  public void OnHit() {
    health--;
    animator.SetTrigger("cutting");

    if (health <= 0) {
      animator.SetTrigger("cut");
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Axe")) {
      OnHit();
    }
  }
}
