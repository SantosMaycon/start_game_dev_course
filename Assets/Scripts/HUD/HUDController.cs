using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
  [SerializeField] private Image waterUiBar, woodUiBar, carrotUiBar;
  private PlayerItems items;
  void Awake() {
    items = FindObjectOfType<PlayerItems>();  
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
    }
  }
}
