using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject {
  [Header("Settings")]
  public GameObject actors;

  [Header("Dialogue")]
  public Sprite speakersSprite;
  public string sentence;

  public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences {
  public string actorName;
  public Sprite profile;
  public Languages sentence;
}

[System.Serializable]
public class Languages {
  public string portuguese;
  public string english;
  public string spanish;
}
