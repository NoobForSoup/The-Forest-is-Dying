using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    private bool activeDialogue = false;

    [Header("Dialogue")]
    public GameObject dialogueBox;

    public Text dialogueContent;

    [Header("Events")]
    [Space]
    public UnityEvent OnEndEvent;

    private void Start()
    {
        if (OnEndEvent == null)
        {
            OnEndEvent = new UnityEvent();
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0)) && activeDialogue)
        {
            NextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        activeDialogue = true;
        
        if(sentences == null)
        {
            sentences = new Queue<string>();
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("NewText");
        }
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        string content = sentence;

        StopAllCoroutines();

        bool newName = false;
        bool textStyle = false;

        if(sentence.Contains("@small"))
        {
            dialogueContent.fontSize = 30;
        }
        else
        {
            dialogueContent.fontSize = 50;
        }

        if (sentence.Contains("@cursive") && sentence.Contains("@bold"))
        {
            dialogueContent.fontStyle = FontStyle.BoldAndItalic;
            textStyle = true;
        }
        else
        if (sentence.Contains("@cursive"))
        {
            dialogueContent.fontStyle = FontStyle.Italic;
            textStyle = true;
        }
        else
        if (sentence.Contains("@bold"))
        {
            dialogueContent.fontStyle = FontStyle.Bold;
            textStyle = true;
        }
        else
        {
            dialogueContent.fontStyle = FontStyle.Normal;
        }

        int i = 0;

        if (newName)
        {
            i++;
        }
        if (textStyle)
        {
            i++;
        }

        content = GetLines(sentence, i);

        dialogueContent.text = content;
    }

    private string GetLines(string sentence, int startLine)
    {
        string[] split = sentence.Split('\n');

        string content = "";

        for (int i = startLine; i < split.Length; i++)
        {
            content += split[i] + "\n";
        }

        return content;
    }

    public void EndDialogue()
    {
        OnEndEvent.Invoke();
        activeDialogue = false;
    }
}
