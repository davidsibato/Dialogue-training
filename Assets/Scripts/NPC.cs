using UnityEngine;
using TMPro;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject continueButton;
    public TextMeshProUGUI dialogueText;
    //public string[] dialogue;
    private int index;
    public float dialogueSpeed;
    public bool playerIsClose;
    public DialogueEvent dialogueEvent;





    void Start()
    {
        EventManager.npcEvents.Add("NPC", dialogueEvent);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && playerIsClose)
        {

            if (EventManager.npcEvents.ContainsKey("NPC"))
            {
                dialoguePanel.SetActive(true);
                Debug.Log("dialogue=> "+ dialogueText.text);
                DialogueStart();
                dialogueEvent = EventManager.npcEvents["NPC"];
                
                
                continueButton.SetActive(true);
            }
        }
    }

    public void DialogueEnd()
    {
        dialogueText.text = "";
        index = 0;
        dialogueEvent = null;
        dialoguePanel.SetActive(false);
    }

    IEnumerator DialogueStart()
    {
        //Debug.Log("dialogue=> " + dialogue[index]);
        //dialogueText.text = "";
        
        string currentDialogue =dialogueEvent.dialogue[index]; 

        for (int i = 0; i < currentDialogue.Length; i++)
        {
            dialogueText.text = currentDialogue.Substring(0, i + 1); 
            yield return new WaitForSeconds(dialogueSpeed); 
        }

        continueButton.SetActive(true); 
    }



public void _NextLine()
    {
        continueButton.SetActive(false);

        if (index < dialogueEvent.dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(DialogueStart());
        }
        else
        {
            DialogueEnd();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            DialogueEnd();
        }
    }
}