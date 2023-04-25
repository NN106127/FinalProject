using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;

    public string[] dialogue;
    public float delay = 0.1f;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            if (index < dialogue.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(TypeSentence(dialogue[index]));
            }
            else
            {
                dialogueBox.SetActive(false);
                dialogueText.text = "";
                index = 0;
            }
        }
    }
    public void StartDialogue()
    {
        dialogueBox.SetActive(true);
        StartCoroutine(TypeSentence(dialogue[index]));
    }
    

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }
}
