using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
  public static AudioManager instance;
  
  // Start is called before the first frame update
  void Start() {
    if (instance == null) {
      instance = this;
      DontDestroyOnLoad(instance);
    } else {
      Destroy(gameObject);
    }
  }
}
