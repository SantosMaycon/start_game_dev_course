using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
  public float speed;
  private int _index;
  public List<Transform> paths = new List<Transform>();
  private Animator animator;

  // Start is called before the first frame update
  void Start() {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {
    transform.position = Vector2.MoveTowards(transform.position, paths[_index].position, speed * Time.deltaTime);

    if (Vector2.Distance(transform.position, paths[_index].position) < 0.1f) {
      if (_index < paths.Count - 1) {
        _index++;
      } else {
        _index = 0;
      }
    }

    Vector2 direction = paths[_index].position - transform.position;
    transform.localScale = new Vector2(Mathf.Sign(direction.x), 1f);
    animator.SetBool("isWalk", true);
  }
}
