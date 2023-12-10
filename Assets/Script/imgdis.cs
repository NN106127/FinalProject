using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imgdis : MonoBehaviour
{
    public float fadeSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = this.GetComponent<Image>().color;
        color.a -= fadeSpeed * Time.deltaTime;
        this.GetComponent<Image>().color = color;
    }
}
