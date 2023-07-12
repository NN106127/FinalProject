using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closebtn : MonoBehaviour
{
    public GameObject background;
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            background.SetActive(false);
            img.SetActive(false);
        }
    }
    public void OnClick()
    {
        background.SetActive(false);
        img.SetActive(false);
    }


}
