using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] private float timeToMove;

  private float timeCount;
  // Start is called before the first frame update
  void Start() {
      
  }

  // Update is called once per frame
  void Update() {
    timeCount += Time.deltaTime;

    if (timeCount < timeToMove) {
      transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      other.GetComponent<PlayerItems>().woods++;
      Destroy(gameObject);
    }
  }
}
