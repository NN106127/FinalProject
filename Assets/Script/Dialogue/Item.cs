using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public DialogueSystem dialogueSystem;
    public DialogueSystem2 dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        dialogueSystem.ShowDialog();
        /*if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogue();
        }*/
    }
}
