using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour {
  public float sizeRange;
  public LayerMask playeLayer;

  // Start is called before the first frame update
  void Start() {
      
  }

  // Update is called once per frame
  void FixedUpdate() {
    ShowDialogue();
  }

  void ShowDialogue() {
    Collider2D hit = Physics2D.OverlapCircle(transform.position, sizeRange, playeLayer);

    if (hit) {
      Debug.Log("*********************");
    }
  }

  private void OnDrawGizmosSelected() {
    Gizmos.DrawWireSphere(transform.position, sizeRange);
  }
}
