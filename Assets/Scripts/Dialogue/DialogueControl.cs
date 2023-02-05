using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {
  [System.Serializable]
  public enum Idiom {
    pt,
    eng,
    es
  }

  public Idiom language;

  [Header("Components")]
  public GameObject dialogueObject;
  public Image profileSprite;
  public Text speechText;
  public Text actorNameText;

  [Header("Settings")]
  public float typingSpeed;

  public bool isShowing;
  private int _index;
  private string[] setences;

  public static DialogueControl instance;

  void Awake() {
    instance = this;  
  }

  // Start is called before the first frame update
  void Start() {
    
  }

  // Update is called once per frame
  void Update() {
    
  }

  IEnumerator TypeSentence() {
    foreach (char letter in setences[_index].ToCharArray()) {
      speechText.text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }
  }

  public void NextSetence() {
    if (speechText.text == setences[_index]) {
      if (_index < setences.Length - 1 ) {
        _index++;
        speechText.text = "";
        StartCoroutine(TypeSentence());
      } else {
        dialogueObject.SetActive(false);
        _index = 0;
        isShowing = false;
      }
    }
  }

  public void Speech(string[] texts) {
    if (!isShowing) {
      speechText.text = "";
      dialogueObject.SetActive(true);
      setences = texts;
      StartCoroutine(TypeSentence());
      isShowing = true;
    }
  }
}
