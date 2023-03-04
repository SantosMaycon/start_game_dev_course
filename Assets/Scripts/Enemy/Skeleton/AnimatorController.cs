using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
  [SerializeField] private float attackRadius;
  [SerializeField] private Transform pointOfAttack;
  [SerializeField] private LayerMask playerLayer;
  private Animator animator;
  // Start is called before the first frame update
  void Start() {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {}

  public void Play(int value) {
    animator.SetInteger("Transition", value);
  }

  public void PlayTrigger(string value) {
    animator.SetTrigger(value);
  }

  public void Attack() {
    Collider2D hit = Physics2D.OverlapCircle(pointOfAttack.position, attackRadius, playerLayer);

    if (hit) {
      hit.GetComponent<Player>()?.OnHit();
    }
  }

  
  private void OnDrawGizmosSelected() {
    Gizmos.DrawWireSphere(pointOfAttack.position, attackRadius);
  }
}
