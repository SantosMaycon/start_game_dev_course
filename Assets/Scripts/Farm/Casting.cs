using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting :MonoBehaviour {
  [Range(0f, 1f)]
  [SerializeField] private float percentage;
  [SerializeField] private GameObject fishPrefab;
  private bool detectingPlayer;
  private PlayerItems items;
  private Animator animator;
  // Start is called before the first frame update
  void Start() {
    items = FindObjectOfType<PlayerItems>();
    animator = items.GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {
    if (detectingPlayer && Input.GetKeyDown(KeyCode.E)) {
      animator.SetTrigger("Casting");
    }
  }

  public void OnDropFish() {
    float chance = Random.Range(0f, 1f);
    Debug.Log(transform.localScale.x);
    if (percentage > chance) {
      Instantiate(fishPrefab, items.transform.position + new Vector3(Random.Range(-2.5f, -1) * transform.localScale.x, 0f, 0f), Quaternion.identity);
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
