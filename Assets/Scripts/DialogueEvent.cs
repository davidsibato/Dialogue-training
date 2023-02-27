using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "Dialogue Event")]
public class DialogueEvent : ScriptableObject
{
    public string[] dialogue;
}
