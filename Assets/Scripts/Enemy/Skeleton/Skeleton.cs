using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour {
  private NavMeshAgent navMeshAgent;
  private Player player;
  private AnimatorController animator;

  [SerializeField] private float timeToAttacks;
  private float recoveryTime;
  // Start is called before the first frame update
  void Start() {
    player = FindObjectOfType<Player>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshAgent.updateRotation = false;
    navMeshAgent.updateUpAxis = false;

    animator = FindObjectOfType<AnimatorController>();
    recoveryTime = timeToAttacks;
  }

  // Update is called once per frame
  void Update() {
    navMeshAgent.SetDestination(player.transform.position);
    bool isCloseToThePlayer = Vector2.Distance(transform.position, player.transform.position) <= navMeshAgent.stoppingDistance;
   
    
    if(navMeshAgent.velocity.x != 0) {
      transform.localScale = new Vector3(Mathf.Sign(navMeshAgent.velocity.x), 1f, 1f);
    }

    if (isCloseToThePlayer) {
      recoveryTime += Time.deltaTime;
    }

    if (isCloseToThePlayer) {
      animator.Play(0);
      if(recoveryTime >= timeToAttacks) {
        animator.PlayTrigger("attack");
        recoveryTime = 0f;
      }
    } else {
      animator.Play(1);
    }
  }
}
