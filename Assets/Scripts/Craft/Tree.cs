using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
  [SerializeField] private float health;
  [SerializeField] private GameObject woodPrefab;
  [SerializeField] private int totalWood;
  private Animator animator;
  private bool isCut = false;
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
      isCut = true;
      animator.SetTrigger("cut");
      for (int i = 0; i < totalWood; i++) {
        Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Axe") && !isCut) {
      OnHit();
    }
  }
}
