using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {
  [Header("Components")]
  public GameObject dialogueObject;
  public Image profileSprite;
  public Text speechText;
  public Text actorNameText;

  [Header("Settings")]
  public float typingSpeed;

  private bool _isShowing;
  private int _index;
  private string[] setences;

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

  }

  public void Speech(string[] texts) {
    if (!_isShowing) {
      dialogueObject.SetActive(true);
      setences = texts;
      StartCoroutine(TypeSentence());
      _isShowing = true;
    }
  }
}
