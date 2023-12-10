using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeOut : MonoBehaviour
{   
    public float fadeSpeed = 0.3f;
    // Update is called once per frame
    void Update()
    {
        Color color = this.GetComponent<Text>().color;
        color.a -= fadeSpeed * Time.deltaTime;
        this.GetComponent<Text>().color = color;

        if(this.GetComponent<Text>().color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
