using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {
  public int woods;
  public int carrots;
  public float water;
  private float waterLimit = 75f;

  public void SetWater(float value) {
    water += water <= waterLimit ? value : 0;
  }
}
