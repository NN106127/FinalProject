using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openitem2 : MonoBehaviour
{
    public GameObject item;
    public float delay = 2.0f; // 延遲時間（以秒為單位）
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.activeSelf == true)
        {
            
            StartCoroutine(ShowImageAfterDelay());
        }
        else
        {
            item.SetActive(false);
        }
            // 啟動 Coroutine 以延遲顯示圖片
        StartCoroutine(ShowImageAfterDelay());
    }
    private System.Collections.IEnumerator ShowImageAfterDelay()
    {
        // 等待指定的延遲時間
        yield return new WaitForSeconds(delay);

        // 顯示圖片
        item.SetActive(true);
    }
}
