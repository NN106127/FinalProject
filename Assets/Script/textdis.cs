using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textdis : MonoBehaviour
{
    public float fadeSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = this.GetComponent<Text>().color;
        color.a -= fadeSpeed * Time.deltaTime;
        this.GetComponent<Text>().color = color;
    }
}
