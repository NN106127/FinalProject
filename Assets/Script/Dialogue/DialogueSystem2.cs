using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem2 : MonoBehaviour
{
    public GameObject dialogBox; // ��ܮت���
    public Text dialogText; // ��ܮؤ�r
    public string[] dialogLines; // ��ܤ��e
    public int currentLine; // �ثe��ܦ��
    public bool dialogActive; // ��ܮجO�_���
    public float typeSpeed; // ���r�t��
    private bool textFinished; // ��r�O�_��X����

    public AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false); // ��ܮؤ@�}�l�����
        textFinished = true; // ��r�@�}�l����X����
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            currentLine++;
            if (currentLine < dialogLines.Length)
            {
                StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
                
            }
            else
            {
                dialogBox.SetActive(false); // �Ҧ���ܵ����A���ù�ܮ�
                dialogActive = false;
                currentLine = 0;
                dialogText.text = "";
            }
        }
    }
    IEnumerator TypeLine(string line)
    {
        textFinished = false; // �}�l��X��r�A�NtextFinished�]��false
        dialogText.text = ""; // �N��ܮؤ�r���M��
        foreach (char c in line.ToCharArray())
        {
            
            dialogText.text += c; // �@�Ӥ@�Ӧr����X��r
            m_audio.Play();
            yield return new WaitForSeconds(typeSpeed); // ����typeSpeed��A��X�U�@�Ӧr��
            
        }
        textFinished = true; // ��X�����A�NtextFinished�]��true
    }

    public void ShowDialog()
    {
        dialogActive = true; // ��ܹ�ܮ�
        dialogBox.SetActive(true);
        StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
    }
}
