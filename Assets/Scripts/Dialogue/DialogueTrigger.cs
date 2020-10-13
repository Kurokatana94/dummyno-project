using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public PlayerController player;
    public DialogueManager dialogueManager;
    private bool inTrigger;

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetButtonDown("Interaction") && player.isStaticInteraction == false)
            {
                dialogueManager.StartDialogue(dialogue);
                player.isStaticInteraction = true;
            }else if(Input.GetButtonDown("Interaction") && player.isStaticInteraction == true)
            {
                dialogueManager.DisplayNextSentence();
            }
            
            if (dialogueManager.isOngoing == false)
            {
                player.isStaticInteraction = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
            inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inTrigger = false;
    }
}
