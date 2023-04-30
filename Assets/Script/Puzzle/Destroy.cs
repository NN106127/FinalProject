using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public bool CanDestroy;
    public GameObject B;
    void Update()
    {
        if(CanDestroy == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(B);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanDestroy = true;
        }
    }
}
