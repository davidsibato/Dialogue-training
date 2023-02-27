using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Dictionary<string, DialogueEvent> npcEvents = new Dictionary<string, DialogueEvent>();

    void Start()
    {
        DialogueEvent NPC1DialogueEvent = Resources.Load<DialogueEvent>("NPC1");
        DialogueEvent NPC2DialogueEvent = Resources.Load<DialogueEvent>("NPC2");
        DialogueEvent tutorialDialogueEvent = Resources.Load<DialogueEvent>("Tutorial");

        npcEvents.Add("NPC1", NPC1DialogueEvent);
        npcEvents.Add("NPC2", NPC2DialogueEvent);
        npcEvents.Add("Tutorial", tutorialDialogueEvent);
    }

}