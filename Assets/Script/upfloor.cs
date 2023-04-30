using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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

    public float speed = 0.1f;
    private float targetIntensity = 0f;

    public Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        // 取得Post Processing Volume
        var volume = GetComponent<PostProcessVolume>();

        // 取得Vignette效果
        if (volume.profile.TryGetSettings(out vignette))
        {
            Debug.Log(1);
            // 初始化Vignette intensity
            vignette.intensity.value = 0f;
        }
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

                    targetIntensity = 1f;
                    // 讓當前intensity值往目標intensity值緩慢遞近
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetIntensity, Time.deltaTime * speed);

                    // 如果當前intensity值已經接近目標intensity值，則將目標intensity值設回0
                    if (Mathf.Abs(vignette.intensity.value - targetIntensity) < 0.01f)
                    {
                        targetIntensity = 0f;
                    }
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

                    targetIntensity = 1f;
                    // 讓當前intensity值往目標intensity值緩慢遞近
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetIntensity, Time.deltaTime * speed);

                    // 如果當前intensity值已經接近目標intensity值，則將目標intensity值設回0
                    if (Mathf.Abs(vignette.intensity.value - targetIntensity) < 0.01f)
                    {
                        targetIntensity = 0f;
                    }
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
