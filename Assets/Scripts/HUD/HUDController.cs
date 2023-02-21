using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
  [Header("Items")]
  [SerializeField] private Image waterUiBar;
  [SerializeField] private Image woodUiBar;
  [SerializeField] private Image carrotUiBar;
  [Header("Tools")]
  [SerializeField] private Image[] tools;
  [SerializeField] private Color selectedColor;
  [SerializeField] private Color unselectedColor;
  private PlayerItems items;
  private Player player;
  void Awake() {
    items = FindObjectOfType<PlayerItems>();  
    player = items.GetComponent<Player>();
  }

  // Start is called before the first frame update
  void Start() {
    waterUiBar.fillAmount = 0f;
    woodUiBar.fillAmount = 0f;
    carrotUiBar.fillAmount = 0f;
  }

  // Update is called once per frame
  void Update() {
    if (items && waterUiBar && woodUiBar && carrotUiBar) {
      waterUiBar.fillAmount = items.water / items.waterLimit;
      woodUiBar.fillAmount = items.woods / items.woodLimit;
      carrotUiBar.fillAmount = items.carrots / items.carrotLimit;

      foreach (var tool in tools) {
        var tag = player.GetAction();
        if (tag != "" && tool.CompareTag(tag)) {
          tool.color = selectedColor;
        } else {
          tool.color = unselectedColor;
        }
      }
    }
  }
}
