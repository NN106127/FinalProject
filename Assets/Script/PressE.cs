using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE : MonoBehaviour
{
    public GameObject Obj;
    // Start is called before the first frame update
    void Start()
    {
        Obj.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("IN");
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                Obj.SetActive(true);
            }
        }
    }
}
