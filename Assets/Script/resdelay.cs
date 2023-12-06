using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resdelay : MonoBehaviour
{
    public float delayTime = 1.5f; // 延迟时间
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (item.activeSelf == true)
        {
            //Debug.Log(1);
            Invoke("ShowImage", delayTime); // 延迟调用 ShowImage 方法
        }
        else
        {
            
        }
    }
    void ShowImage()
    {
        //Debug.Log(2);
        item.SetActive(false);
    }
}
