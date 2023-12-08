using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chget : MonoBehaviour
{
    public GameObject Destroyed;
    public GameObject get;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Destroyed == null)
        {
            get.SetActive(true);
        }
        else
        {
            get.SetActive(false);
        }
    }
}
