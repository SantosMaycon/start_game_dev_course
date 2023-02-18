using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField] private float speed;
  [SerializeField] private float runSpeed;
  private Rigidbody2D rigidbody2d;
  private Animator animator;
  private Vector2 direction;
  private bool isAction = false;
  private float initialSpeed;
  private string action = "";

  private PlayerItems items;

  // Start is called before the first frame update
  void Start() {
    rigidbody2d = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    items = GetComponent<PlayerItems>();
    initialSpeed = speed;
  }

  // Update is called once per frame
  void Update() {
    OnChooseAction();
    OnInput();
    OnRun();
    OnRoll();
    OnAction();

    if (isAction && items.water > 0) {
      items.SetWater(-0.01f);
    }

    if (action == "isWater" && items.water <= 0 && isAction) {
      isWater();
    }
  }

  void FixedUpdate() {
    OnMove();
  }

  #region Movement
    void OnInput() {
      direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }   

    void OnMove() {
      if (direction.x != 0) {
        transform.localScale = new Vector2(Mathf.Sign(direction.x), transform.localScale.y);
      }

      rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.fixedDeltaTime);
      animator.SetBool("isWalk", direction.magnitude != 0);
    } 

    void OnRun() {
      if (Input.GetKeyDown(KeyCode.LeftShift)) {
        animator.SetBool("isRun", true);
        speed = runSpeed;
      }

      if (Input.GetKeyUp(KeyCode.LeftShift)) {
        animator.SetBool("isRun", false);
        speed = initialSpeed;
      }
    }
    void OnRoll() {
      if (Input.GetMouseButtonDown(1)) {
        animator.SetTrigger("Rolling");
      }
    }

    void OnChooseAction() {
      OnAnimationActionInput(KeyCode.Alpha1, "isCut");      
      OnAnimationActionInput(KeyCode.Alpha2, "isDig");
      OnAnimationActionInput(KeyCode.Alpha3, "isWater");
    }

    void OnAction() {
      if (Input.GetMouseButtonDown(0) && action != "") {
        isAction = true;
        Invoke(action, 0f);
        speed = 0f;
      }

      if (Input.GetMouseButtonUp(0) && action != "") {
        isAction = false;
        Invoke(action, 0f);
        speed = initialSpeed;
      }
    }

    void isCut() {
      animator.SetBool(action, isAction);
    }
    void isDig() {
      animator.SetBool(action, isAction);
    }
    void isWater() {
      animator.SetBool(action, isAction && items.water > 0);
    }

  #endregion

  void OnAnimationActionInput(KeyCode keyCode, string action) {
    if (Input.GetKeyDown(keyCode) && !isAction) {
      this.action = action;
    }
  }
}
