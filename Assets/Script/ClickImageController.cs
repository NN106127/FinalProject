using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickImageController : MonoBehaviour
{
    public GameObject story;

    public Text dialogText;

    public string[] dialogLines; // 對話內容
    public int currentLine; // 目前對話行數
    public float typeSpeed; // 打字速度
    private bool textFinished; // 文字是否輸出完成
    private bool dialogShown = false;
    // Start is called before the first frame update
    void Start()
    {
        story.SetActive(false);
        textFinished = true; // 文字一開始為輸出完成
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnObjectClicked()
    {
        GameObject playerObj = GameObject.Find("Player");
        Player playerScript = playerObj.GetComponent<Player>();
        playerScript.isMovementEnabled = false;
        story.SetActive(true);
        if (textFinished && !dialogShown)
        {
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }


    }
    IEnumerator TypeLine(string line)
    {
        textFinished = false; // 開始輸出文字，將textFinished設為false
        dialogText.text = ""; // 將對話框文字先清空
        foreach (char c in line.ToCharArray())
        {

            dialogText.text += c; // 一個一個字元輸出文字
            //m_audio.Play();
            yield return new WaitForSeconds(typeSpeed); // 等待typeSpeed秒再輸出下一個字元

        }
        textFinished = true; // 輸出完成，將textFinished設為true
        dialogShown = true;

    }

}
