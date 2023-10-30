using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用Unity UI程式庫。
using UnityEngine.SceneManagement;

public class videoplay : MonoBehaviour
{
    public int m_seconds;                 //倒數計時經換算的總秒數

    public int m_min;              //用於設定倒數計時的分鐘
    public int m_sec;             //用於設定倒數計時的秒數

    public GameObject img;
    public GameObject black;
    public GameObject music;
    public float delay = 2.0f; // 延遲時間（以秒為單位）

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());   //呼叫倒數計時的協程
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            music.SetActive(false);
            black.SetActive(true);
            StartCoroutine(ShowImageAfterDelay());

        }
    }
    IEnumerator Countdown()
    {

        m_seconds = (m_min * 60) + m_sec;       //將時間換算為秒數

        while (m_seconds > 0)                   //如果時間尚未結束
        {
            yield return new WaitForSeconds(1); //等候一秒再次執行

            m_seconds--;                        //總秒數減 1
            m_sec--;                            //將秒數減 1

            if (m_sec < 0 && m_min > 0)         //如果秒數為 0 且分鐘大於 0
            {
                m_min -= 1;                     //先將分鐘減去 1
                m_sec = 59;                     //再將秒數設為 59
            }
            else if (m_sec < 0 && m_min == 0)   //如果秒數為 0 且分鐘大於 0
            {
                m_sec = 0;                      //設定秒數等於 0
            }

        }
        black.SetActive(true);
        yield return new WaitForSeconds(5);   //時間結束時，顯示 00:00 停留一秒
        
        SceneManager.LoadScene(2);       //時間結束時，畫面出現 GAME OVER

    }
    private System.Collections.IEnumerator ShowImageAfterDelay()
    {
        // 等待指定的延遲時間
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }
}
