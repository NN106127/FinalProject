using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogBox; // ��ܮت���
    public Text dialogText; // ��ܮؤ�r
    public string[] dialogLines; // ��ܤ��e
    public string[] nextDialogLines; // ��ܤ��e
    public int currentLine; // �ثe��ܦ��
    public bool dialogActive1; // ��ܮجO�_���
    public bool dialogActive2; // ��ܮجO�_���
    public float typeSpeed; // ���r�t��
    private bool textFinished; // ��r�O�_��X����
    public Sprite[] characterImages;// �b DialogueSystem ���s�W�@�� public �� Sprite[] �}�C�A�Ω�s�񤣦P������Ϥ�
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
        dialogBox.SetActive(false); // ��ܮؤ@�}�l�����
        textFinished = true; // ��r�@�}�l����X����
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive1 && Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            buttonsound.Play();
            currentLine++;
            // �ˬd�O�_�ݭn��������Ϥ�
            CheckAndSwitchCharacter(currentLine);
            if (currentLine < dialogLines.Length)
            {
                StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{

            }
            else
            {
                playerimg1.SetActive(false);
                playerimg2.SetActive(false);
                dialogBox.SetActive(false); // �Ҧ���ܵ����A���ù�ܮ�
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
                StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{

            }
            else
            {
                playerimg1.SetActive(false);
                playerimg2.SetActive(false);
                dialogBox.SetActive(false); // �Ҧ���ܵ����A���ù�ܮ�
                dialogActive2 = false;
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
            //m_audio.Play();
            yield return new WaitForSeconds(typeSpeed); // ����typeSpeed��A��X�U�@�Ӧr��

        }
        textFinished = true; // ��X�����A�NtextFinished�]��true
    }
    void CheckAndSwitchCharacter(int lineIndex)
    {
        // �ھڻݭn��������ܦ�ơA��s��ܪ�����Ϥ�
        if (lineIndex == 3)
        {
            // ������Ĥ@�Ө���Ϥ�
            playerimg1.GetComponent<Image>().sprite = characterImages[0];
        }
        else if (lineIndex == 5)
        {
            // ������ĤG�Ө���Ϥ�
            playerimg1.GetComponent<Image>().sprite = characterImages[1];
        }
        else if (lineIndex == 6)
        {
            // ������ĤG�Ө���Ϥ�
            playerimg1.GetComponent<Image>().sprite = characterImages[2];
        }
        else if (lineIndex == 8)
        {
            // ������ĤG�Ө���Ϥ�
            playerimg1.GetComponent<Image>().sprite = characterImages[3];
        }
        else if (lineIndex == 9)
        {
            // ������ĤG�Ө���Ϥ�
            playerimg1.GetComponent<Image>().sprite = characterImages[4];
        }
        else if (lineIndex == 10)
        {
            // ������ĤG�Ө���Ϥ�
            playerimg1.GetComponent<Image>().sprite = characterImages[5];
        }
        
    }


    public void Showech2Dialog()
    {

        if (GameObject.FindGameObjectWithTag("ch2").transform.Find("ch2"))
        {
            shock.Play();
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            shock.Stop();
            Debug.Log(gameObject);
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }

    public void Showech3Dialog()
    {

        if (GameObject.FindGameObjectWithTag("ch3").transform.Find("ch3"))
        {
            shock.Play();
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            shock.Stop();
            Debug.Log(gameObject);
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }

}