using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour {
  public float sizeRange;
  public LayerMask playeLayer;
  public DialogueSettings dialogue;
  bool playerHit;
  private List<string> sentences = new List<string>();

  // Start is called before the first frame update
  void Start() {
    GetNPCInfo();
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.E) && playerHit) {
      DialogueControl.instance.Speech(sentences.ToArray());
    }  
  }

  void GetNPCInfo() {
    for (int i = 0; i < dialogue.dialogues.Count; i++) {
      switch (DialogueControl.instance.language) {
        case DialogueControl.Idiom.pt:
          sentences.Add(dialogue.dialogues[i].sentence.portuguese);
          break;
        case DialogueControl.Idiom.eng:
          sentences.Add(dialogue.dialogues[i].sentence.english);
          break;
        case DialogueControl.Idiom.es:
          sentences.Add(dialogue.dialogues[i].sentence.spanish);
          break;
      }
    }
  }

  void FixedUpdate() {
    ShowDialogue();
  }

  void ShowDialogue() {
    Collider2D hit = Physics2D.OverlapCircle(transform.position, sizeRange, playeLayer);

    if (hit) {
      playerHit = true;
    } else {
      playerHit = false;
      DialogueControl.instance.dialogueObject.SetActive(false);
      DialogueControl.instance.isShowing = false;
    }
  }

  private void OnDrawGizmosSelected() {
    Gizmos.DrawWireSphere(transform.position, sizeRange);
  }
}
