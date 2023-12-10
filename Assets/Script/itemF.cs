using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemF : MonoBehaviour
{
    public GameObject F1;
    public GameObject fish;
    public GameObject back;
    public GameObject memory;
    bool CanF;
    public AudioSource m_audio;
    private void Update()
    {
        if(CanF == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                GameObject playerObj = GameObject.Find("Player");
                Player playerScript = playerObj.GetComponent<Player>();
                Animator animator = playerObj.GetComponent<Animator>();
                animator.speed = 0;
                playerScript.enabled = false;
                fish.SetActive(true);
                back.SetActive(true);
                memory.SetActive(false);
                m_audio.Play();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject playerObj = GameObject.Find("Player");
                Player playerScript = playerObj.GetComponent<Player>();
                Animator animator = playerObj.GetComponent<Animator>();
                animator.speed = 1;
                playerScript.enabled = true;
                fish.SetActive(false);
                back.SetActive(false);
                memory.SetActive(true);
                m_audio.Stop();
            }
        }
        
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanF = true;
            F1.SetActive(true);
            //Debug.Log("F");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            F1.SetActive(false);
            fish.SetActive(false);
            back.SetActive(false);
            CanF = false;
            m_audio.Stop();
            //Debug.Log("OUT");
        }
          
    }
}
