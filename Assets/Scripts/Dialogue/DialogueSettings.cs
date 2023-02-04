using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

#if UNITY_EDITOR
  [CustomEditor(typeof(DialogueSettings))]
  public class BuilderEditor: Editor {
    public override void OnInspectorGUI() {
      DrawDefaultInspector();

      DialogueSettings ds = (DialogueSettings)target;

      Languages languages = new Languages();
      languages.portuguese = ds.sentence;

      Sentences sentences = new Sentences();
      sentences.profile = ds.speakersSprite;
      sentences.sentence = languages;

      if (GUILayout.Button("Create Dialogue")) {
        if (ds.sentence != "") {
          ds.dialogues.Add(sentences);

          ds.speakersSprite = null;
          ds.sentence = "";
        }
      }
    }
  } 
#endif