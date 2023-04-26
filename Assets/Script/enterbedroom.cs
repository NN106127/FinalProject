using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterbedroom : MonoBehaviour
{
    public Transform bedroomTransform;
    public Transform secondFloorTransform; // 二樓的位置
    public Transform playerTransform; // 人物的Transform組件
    public float teleportRange = 1.0f; // 傳送範圍
    public GameObject cam2;
    public GameObject cam3;
    public GameObject enter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 檢查玩家是否在傳送範圍內
            if (Vector2.Distance(playerTransform.position, bedroomTransform.position) <= teleportRange)
            {
                // 移動人物到一樓開啟一樓攝影機
                playerTransform.position = bedroomTransform.position;
                
                cam2.SetActive(false);
                cam3.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // 檢查玩家是否在傳送範圍內
            if (Vector2.Distance(playerTransform.position, secondFloorTransform.position) <= teleportRange)
            {
                // 移動人物到二樓開啟二樓攝影機
                playerTransform.position = secondFloorTransform.position;

                cam3.SetActive(false);
                cam2.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            enter.SetActive(true);

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            enter.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            enter.SetActive(false);

        }

    }
}
