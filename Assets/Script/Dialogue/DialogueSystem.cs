using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogBox; // 對話框物件
    public Text dialogText; // 對話框文字
    public string[] dialogLines; // 對話內容
    public string[] nextDialogLines; // 對話內容
    public int currentLine; // 目前對話行數
    public bool dialogActive1; // 對話框是否顯示
    public bool dialogActive2; // 對話框是否顯示
    public float typeSpeed; // 打字速度
    private bool textFinished; // 文字是否輸出完成
    public Sprite[] characterImages;// 在 DialogueSystem 中新增一個 public 的 Sprite[] 陣列，用於存放不同的角色圖片
    public GameObject playerimg1;
    public GameObject playerimg2;
    public AudioSource m_audio;
    public AudioSource buttonsound;
    public AudioSource shock;
    // Start is called before the first frame update
    void Start()
    {
        playerimg1.SetActive(false);
        playerimg2.SetActive(false);
        dialogBox.SetActive(false); // 對話框一開始不顯示
        textFinished = true; // 文字一開始為輸出完成
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive1 && Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            buttonsound.Play();
            currentLine++;
            // 檢查是否需要切換角色圖片
            CheckAndSwitchCharacter(currentLine);
            if (currentLine < dialogLines.Length)
            {
                StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程

            }
            else
            {
                playerimg1.SetActive(false);
                playerimg2.SetActive(false);
                dialogBox.SetActive(false); // 所有對話結束，隱藏對話框
                dialogActive1 = false;
                currentLine = 0;
                dialogText.text = "";
            }
        }
        if (dialogActive2 && Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            currentLine++;
            if (currentLine < nextDialogLines.Length)
            {
                StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程

            }
            else
            {
                playerimg1.SetActive(false);
                playerimg2.SetActive(false);
                dialogBox.SetActive(false); // 所有對話結束，隱藏對話框
                dialogActive2 = false;
                currentLine = 0;
                dialogText.text = "";
            }
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
    }
    void CheckAndSwitchCharacter(int lineIndex)
    {
        // 根據需要切換的對話行數，更新顯示的角色圖片
        if (lineIndex == 3)
        {
            // 切換到第一個角色圖片
            playerimg1.GetComponent<Image>().sprite = characterImages[0];
        }
        else if (lineIndex == 5)
        {
            // 切換到第二個角色圖片
            playerimg1.GetComponent<Image>().sprite = characterImages[1];
        }
        else if (lineIndex == 6)
        {
            // 切換到第二個角色圖片
            playerimg1.GetComponent<Image>().sprite = characterImages[2];
        }
        else if (lineIndex == 8)
        {
            // 切換到第二個角色圖片
            playerimg1.GetComponent<Image>().sprite = characterImages[3];
        }
        else if (lineIndex == 9)
        {
            // 切換到第二個角色圖片
            playerimg1.GetComponent<Image>().sprite = characterImages[4];
        }
        else if (lineIndex == 10)
        {
            // 切換到第二個角色圖片
            playerimg1.GetComponent<Image>().sprite = characterImages[5];
        }
        
    }


    public void Showech2Dialog()
    {

        if (GameObject.FindGameObjectWithTag("ch2").transform.Find("ch2"))
        {
            shock.Play();
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            shock.Stop();
            Debug.Log(gameObject);
            dialogActive2 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }
    }

    public void Showech3Dialog()
    {

        if (GameObject.FindGameObjectWithTag("ch3").transform.Find("ch3"))
        {
            shock.Play();
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            shock.Stop();
            Debug.Log(gameObject);
            dialogActive2 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }
    }

}