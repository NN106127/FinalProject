using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openitem : MonoBehaviour
{
    public GameObject item;
    public GameObject trigger;
    public GameObject mirrorbtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.activeSelf == true)
        {
            item.SetActive(true);
        }
        else
        {
            item.SetActive(false);
        }
        if (trigger.activeSelf == false)
        {
            mirrorbtn.SetActive(false);
            item.SetActive(false);
        }
    }
}
