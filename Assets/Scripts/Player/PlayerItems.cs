using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {
  [Header("Amounts")]
  public int woods;
  public int carrots;
  public float water;

  [Header("Limits")]
  public float woodLimit = 5f;
  public float carrotLimit = 10f;
  public float waterLimit = 75f;

  public void SetWater(float value) {
    water += water <= waterLimit ? value : 0;
  }
}
