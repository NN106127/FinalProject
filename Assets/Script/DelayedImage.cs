using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedImage : MonoBehaviour
{
    public float delayTime = 1.5f; // 延迟时间
    public GameObject bone;
    public GameObject ice;


    void Start()
    {
        bone.SetActive(false);
        
    }
    void Update()
    {
        if (ice.activeSelf == true)
        {
            //Debug.Log(1);
            Invoke("ShowImage", delayTime); // 延迟调用 ShowImage 方法
        }
        else
        {
            bone.SetActive(false);
        }
    }
    void ShowImage()
    {
        //Debug.Log(2);
        bone.SetActive(true);
    }
   

}
