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
    private System.Action onDialogueEnd; // New field to store the callback

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogue.SetActive(false);
    }

    // Update is called once per frame
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
        onDialogueEnd?.Invoke(); // Invoke the callback if it's set
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

    // Overloaded StartDialogue method that accepts a callback
    public void StartDialogue(string[] dialogueSentences, System.Action onEnd)
    {
        onDialogueEnd = onEnd; // Store the callback
        StartDialogue(dialogueSentences); // Call the original method
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
