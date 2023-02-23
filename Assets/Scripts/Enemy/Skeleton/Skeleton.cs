using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour {
  private NavMeshAgent navMeshAgent;
  private Player player;
  private Animator animator;
  // Start is called before the first frame update
  void Start() {
    player = FindObjectOfType<Player>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshAgent.updateRotation = false;
    navMeshAgent.updateUpAxis = false;

    animator = transform.GetChild(0).GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {
    navMeshAgent.SetDestination(player.transform.position);
    bool isCloseToThePlayer = Vector2.Distance(transform.position, player.transform.position) <= navMeshAgent.stoppingDistance;
   
    animator.SetBool("isWalk", !isCloseToThePlayer);
    
    if(navMeshAgent.velocity.x != 0) {
      transform.localScale = new Vector3(Mathf.Sign(navMeshAgent.velocity.x), 1f, 1f);
    }

    if (isCloseToThePlayer) {} else {}
  }
}
