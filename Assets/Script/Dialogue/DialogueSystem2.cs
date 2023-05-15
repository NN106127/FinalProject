using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem2 : MonoBehaviour
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
    public GameObject playerimg;
    public AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        playerimg.SetActive(false);
        dialogBox.SetActive(false); // 對話框一開始不顯示
        textFinished = true; // 文字一開始為輸出完成
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive1 && Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            currentLine++;
            if (currentLine < dialogLines.Length )
            {
                StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
                
            }
            else
            {
                playerimg.SetActive(false);
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
                playerimg.SetActive(false);
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
            m_audio.Play();
            yield return new WaitForSeconds(typeSpeed); // 等待typeSpeed秒再輸出下一個字元
            
        }
        textFinished = true; // 輸出完成，將textFinished設為true
    }

    public void ShowDialog()
    {
        if (!OpenState.tipsEverOpend)
        {
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
            
        }
        


    }

    public void ShowWardobeDialog()
    {

        if (!OpenState.wardrobeEverOpened)
        {
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            dialogActive2 = true; // 顯示對話框
            
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }

    }
    public void ShowAquariumDialog()
    {

        if (!OpenState.aquariumEverOpened)
        {
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            dialogActive2 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }

    }
    public void ShowFridgeDialog()
    {
        if (GameObject.FindGameObjectWithTag("fridge").transform.Find("一袋骨頭_1"))
        {   
            
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            Debug.Log("C");
            dialogActive2 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }

    }
    public void ShowOvenDialog()
    {

        if (!OpenState.ovenEverOpened)
        {
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            dialogActive2 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }

    }
    public void ShowcalendarDialog()
    {

        if (!OpenState.calendarEverOpend)
        {
            dialogActive1 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
        }
        else
        {
            dialogActive2 = true; // 顯示對話框
            dialogBox.SetActive(true);
            playerimg.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // 開啟文字輸出協程
        }

    }
}