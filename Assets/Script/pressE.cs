using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressE : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            item.SetActive(false);
        }
    }
}
