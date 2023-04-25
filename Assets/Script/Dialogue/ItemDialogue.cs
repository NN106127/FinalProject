using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] sentences;
    public float typingSpeed = 0.25f;

    private bool isTalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTalking)
        {
            isTalking = true;
            StartCoroutine(TypeDialogue());
        }
        
    }

    private IEnumerator TypeDialogue()
    {
        dialogueText.gameObject.SetActive(true);
        foreach (string sentence in sentences)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
                
            }
            /*if (CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
            {
                yield return new WaitForSeconds(typingSpeed = 0.1f);
            }*/
            yield return new WaitForSeconds(2f);
            
            
        }
        dialogueText.gameObject.SetActive(false);
        isTalking = false;
    }
}
