using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upfloor : MonoBehaviour
{
    public Transform playerTransform; // 人物的Transform組件
    //public Transform cameraTransform; // 攝影機的Transform組件
    public Transform firstFloorTransform; // 一樓的位置
    public Transform secondFloorTransform; // 二樓的位置
    public float teleportRange = 1.0f; // 傳送範圍

    public GameObject cam1;
    public GameObject cam2;
    
    public GameObject up;
    public GameObject donwn;
    bool CanW;
    bool CanS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanW == true)
        {
            // 檢測玩家是否按下"W"鍵
            if (Input.GetKeyDown(KeyCode.W))
            {
                // 檢查玩家是否在傳送範圍內
                if (Vector2.Distance(playerTransform.position, secondFloorTransform.position) <= teleportRange)
                {
                    // 移動人物到二樓開起二樓攝影機
                    playerTransform.position = secondFloorTransform.position;
                    cam1.SetActive(false);
                    cam2.SetActive(true);
                }
            }
            
        }
        if (CanS == true)
        {
            // 檢測玩家是否按下"S"鍵
            if (Input.GetKeyDown(KeyCode.S))
            {
                // 檢查玩家是否在傳送範圍內
                if (Vector2.Distance(playerTransform.position, firstFloorTransform.position) <= teleportRange)
                {
                    // 移動人物到一樓開啟一樓攝影機
                    playerTransform.position = firstFloorTransform.position;
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                }
            }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            CanS = true;
            CanW = true;
            up.SetActive(true);
            donwn.SetActive(true);
            

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanS = true;
            CanW = true;
            up.SetActive(true);
            donwn.SetActive(true);
            
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanS = false;
            CanW = false;
            up.SetActive(false);
            donwn.SetActive(false);
            

        }

    }
}
