using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemF : MonoBehaviour
{
    public GameObject F1;
    public GameObject fish;
    bool CanF;

    private void Update()
    {
        if(CanF == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                fish.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanF = true;
            F1.SetActive(true);
            Debug.Log("F");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            F1.SetActive(false);
            fish.SetActive(false);
            CanF = false;
            Debug.Log("OUT");
        }
          
    }
}
