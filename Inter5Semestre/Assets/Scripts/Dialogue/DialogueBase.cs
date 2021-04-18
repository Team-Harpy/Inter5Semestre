using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public CharacterProfile profile;
        [TextArea(4, 8)]
        public string myText;
        public UnityEvent myEvent;
    }

    public Info[] dialogueInfo;
}
