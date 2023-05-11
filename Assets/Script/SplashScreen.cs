using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject splashImage; // UI圖像元素
    public float displayTime = 3.0f; // 顯示時間
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowSplash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShowSplash()
    {
        splashImage.SetActive(true); // 顯示UI圖像元素

        yield return new WaitForSeconds(displayTime); // 等待一段時間

        splashImage.SetActive(false); // 隱藏UI圖像元素
        Destroy(gameObject); // 刪除該遊戲物件
    }
}
