using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House :  MonoBehaviour {
  [SerializeField] private int woodsAmount;
  [SerializeField] private Sprite house;
  [SerializeField] private Color buildingColor;
  [SerializeField] private Color builtColor;
  [SerializeField] private float timeToBuild;
  [SerializeField] private Transform pointOfBuild;
  private bool detectingPlayer;
  private Player player;
  private PlayerItems items;
  private GameObject spriteGameObject;
  private SpriteRenderer spriteRenderer;
  private Animator animator;
  private bool isBuild = false;
  private float _timeToBuild = 0f;
  private BoxCollider2D boxCollider2D;


  // Start is called before the first frame update
  void Start() {
    player = FindObjectOfType<Player>();
    items = FindObjectOfType<PlayerItems>();
    animator = player.GetComponent<Animator>();
    spriteGameObject = transform.GetChild(0).gameObject;
    spriteRenderer = spriteGameObject.GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = house;
    spriteRenderer.color = buildingColor;
    boxCollider2D = GetComponent<BoxCollider2D>();
  }

  // Update is called once per frame
  void Update() {
    if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && !isBuild && items.woods >= woodsAmount) {
      isBuild = true;
      player.transform.position = pointOfBuild.transform.position;
      player.transform.localScale = Vector3.one;
      animator.SetBool("isHammering", true);
      player.isPaused = true;
    }

    if (isBuild) {
      _timeToBuild += Time.deltaTime;

      if (_timeToBuild >= timeToBuild) {
        spriteRenderer.color = builtColor;
        animator.SetBool("isHammering", false);
        player.isPaused = false;
        boxCollider2D.isTrigger = false;
        items.woods -= woodsAmount;
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player") && !isBuild) {
      detectingPlayer = true;
      spriteGameObject.SetActive(true);
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Player") && !isBuild) {
      detectingPlayer = false;
      spriteGameObject.SetActive(false);
    }
  }
}
