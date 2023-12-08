using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public DialogueSystem dialogueSystem;
    public DialogueSystem2 dialogueSystem;
    public DialogueSystem dialogueSystem2;

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
        switch (this.gameObject.tag)
        {
            case "wardrobe":
                dialogueSystem.ShowWardobeDialog();
                break;
            case "aquarium":
                dialogueSystem.ShowAquariumDialog();
                break;
            case "fridge":
                dialogueSystem.ShowFridgeDialog();
                break;
            case "oven":
                dialogueSystem.ShowOvenDialog();
                break;
            case "tips":
                dialogueSystem.ShowDialog();
                break;
            case "calendar":
                dialogueSystem.ShowcalendarDialog();
                break;
            case "mirror":
                dialogueSystem.ShowmirrorDialog();
                break;
            case "doll":
                dialogueSystem.ShowdollDialog();
                break;
            case "electricalbox":
                dialogueSystem.ShowelectricalboxDialog();
                break;
            case "tub":
                dialogueSystem.ShowetubDialog();
                break;
            case "door":
                dialogueSystem.ShowedoorDialog();
                break;
            case "cabinet":
                dialogueSystem.ShowecabinetDialog();
                break;
            case "cupboard":
                dialogueSystem.ShowecupboardDialog();
                break;
            case "Res":
                dialogueSystem.ShoweResDialog();
                break;
            case "ch2":
                dialogueSystem2.Showech2Dialog();
                break;
            case "ch3":
                dialogueSystem2.Showech3Dialog();
                break;
        }
        //dialogueSystem.ShowDialog();
        /*if (collision.CompareTag("Player"))
        {
            dialogueSystem.StartDialogue();
        }*/
    }
}
