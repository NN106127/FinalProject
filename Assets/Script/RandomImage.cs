using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImage : MonoBehaviour
{
    //public GameObject image;
    public float showTime = 0.5f;
    public float hideTime = 2.0f;
    public SpriteRenderer image;
    //public float minDelay = 1f;
    //public float maxDelay = 5f;
    public float minX = -3f;
    public float maxX = -1f;
    public float minY = 1f;
    public float maxY = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowImage());
    }
    private IEnumerator ShowImage()
    {
        while (true)
        {
            // 設定圖片位置
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            transform.position = new Vector3(x, y, 0);

            /*// 顯示圖片
            image.enabled = true;

            // 等待隨機時間
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // 隱藏圖片
            image.enabled = false;*/
            yield return new WaitForSeconds(5.0f); // 等待 5 秒
            image.enabled = true; // 顯示圖片
            yield return new WaitForSeconds(showTime); // 等待 showTime 秒
            image.enabled = false; // 隱藏圖片
            yield return new WaitForSeconds(hideTime); // 等待 hideTime 秒
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*IEnumerator Start()
    {
        while (true)
        {
            
        }
    }*/

}
