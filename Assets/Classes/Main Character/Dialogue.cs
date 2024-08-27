using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    private bool isDialogueOpen = false;
    private System.Action onDialogueEnd; 

    void Start()
    {
        sentences = new Queue<string>();
        dialogue.SetActive(false);
    }

    void Update()
    {
        if (isDialogueOpen && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void OpenDialogue()
    {
        dialogue.SetActive(true);
        isDialogueOpen = true;
    }

    public void CloseDialogue()
    {
        dialogue.SetActive(false);
        isDialogueOpen = false;
        onDialogueEnd?.Invoke(); 
    }

    public void StartDialogue(string[] dialogueSentences)
    {
        OpenDialogue();
        sentences.Clear();

        foreach (string sentence in dialogueSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogue(string[] dialogueSentences, System.Action onEnd)
    {
        onDialogueEnd = onEnd; 
        StartDialogue(dialogueSentences); 
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            CloseDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
}
