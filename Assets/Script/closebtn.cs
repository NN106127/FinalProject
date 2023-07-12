using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closebtn : MonoBehaviour
{
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (background.activeInHierarchy==true)
        {

            Time.timeScale = 0f;
        }
    }
    public void OnClick()
    {
        background.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
