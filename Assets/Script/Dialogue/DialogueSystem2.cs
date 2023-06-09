using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem2 : MonoBehaviour
{
    public GameObject dialogBox; // 對話框物件
    public Text dialogText; // 對話框文字
    public string[] dialogLines; // 對話內容
    public int currentLine; // 目前對話行數
    public bool dialogActive; // 對話框是否顯示
    public float typeSpeed; // 打字速度
    private bool textFinished; // 文字是否輸出完成
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false); // 對話框一開始不顯示
        textFinished = true; // 文字一開始為輸出完成
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            currentLine++;
            if (currentLine < dialogLines.Length)
            {
                StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
            }
            else
            {
                dialogBox.SetActive(false); // 所有對話結束，隱藏對話框
                dialogActive = false;
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
            yield return new WaitForSeconds(typeSpeed); // 等待typeSpeed秒再輸出下一個字元
        }
        textFinished = true; // 輸出完成，將textFinished設為true
    }

    public void ShowDialog()
    {
        dialogActive = true; // 顯示對話框
        dialogBox.SetActive(true);
        StartCoroutine(TypeLine(dialogLines[currentLine])); // 開啟文字輸出協程
    }
}
