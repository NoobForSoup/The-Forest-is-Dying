using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool autoStart = true;

    public void Start()
    {
        if(autoStart)
        {
            Dialogue();
        }
    }

    public void Dialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
