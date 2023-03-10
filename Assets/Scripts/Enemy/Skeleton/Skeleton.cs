using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour {
  [SerializeField] private float health;
  [SerializeField] private Image healthBar;
  private float currentHealth;
  private NavMeshAgent navMeshAgent;
  private Player player;
  private AnimatorController animator;

  [SerializeField] private float timeToAttacks;
  private float recoveryTime;

  [SerializeField] private float areaDetcting;
  [SerializeField] private LayerMask playerLayer;
  private bool isStartFollow;
  // Start is called before the first frame update
  void Start() {
    player = FindObjectOfType<Player>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshAgent.updateRotation = false;
    navMeshAgent.updateUpAxis = false;

    animator = FindObjectOfType<AnimatorController>();
    recoveryTime = timeToAttacks;
    currentHealth = health;
  }

  // Update is called once per frame
  void Update() {
    if (isStartFollow) {
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
        if(recoveryTime >= timeToAttacks && !navMeshAgent.isStopped) {
          animator.PlayTrigger("attack");
          recoveryTime = 0f;
        }
      } else {
        animator.Play(1);
      }
    } else {
      animator.Play(0);
    }
  }

  void FixedUpdate() {
    OnDetectingPlayer();
  }

  public void OnHit() {
    animator.PlayTrigger("hit"); 
    currentHealth--;
    healthBar.fillAmount = currentHealth / health;

    if (currentHealth <= 0f) {
      animator.PlayTrigger("death");
      navMeshAgent.isStopped = true;
      Destroy(gameObject, 1.5f);
    }
  }

  public void OnDetectingPlayer() {
    Collider2D hit = Physics2D.OverlapCircle(transform.position, areaDetcting, playerLayer);

    isStartFollow = hit ? true : false;   
    navMeshAgent.isStopped = !isStartFollow; 
  }

  private void OnDrawGizmosSelected() {
    Gizmos.DrawWireSphere(transform.position, areaDetcting);
  }
}
