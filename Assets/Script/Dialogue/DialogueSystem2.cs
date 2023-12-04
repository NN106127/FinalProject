using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem2 : MonoBehaviour
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
    public GameObject playerimg1;
    public GameObject playerimg2;
    public AudioSource m_audio;
    public AudioSource buttonsound;
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
            if (currentLine < dialogLines.Length )
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

    public void ShowDialog()
    {
        if (!OpenState.tipsEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            playerimg2.SetActive(false);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
            
        }
        


    }

    public void ShowWardobeDialog()
    {

        if (!OpenState.wardrobeEverOpened)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }
    public void ShowAquariumDialog()
    {

        if (!OpenState.aquariumEverOpened)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }
    public void ShowFridgeDialog()
    {
        if (GameObject.FindGameObjectWithTag("fridge").transform.Find("�@�U���Y_1"))
        {   
            
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            Debug.Log("C");
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }
    public void ShowOvenDialog()
    {

        if (!OpenState.ovenEverOpened)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }
    public void ShowcalendarDialog()
    {

        if (!OpenState.calendarEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }
    public void ShowmirrorDialog()
    {

        if (!OpenState.mirrorEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }
    public void ShowdollDialog()
    {

        if (!OpenState.dollEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }

    }

    public void ShowelectricalboxDialog()
    {

        if (!OpenState.electricalboxEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }

    public void ShowetubDialog()
    {

        if (!OpenState.tubEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }

    public void ShowedoorDialog()
    {

        if (!OpenState.doorEverOpend)
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }

    public void ShowecabinetDialog()
    {

        if (GameObject.FindGameObjectWithTag("cabinet").transform.Find("���K"))
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            Debug.Log(gameObject);
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }
    public void ShowecupboardDialog()
    {

        if (GameObject.FindGameObjectWithTag("cupboard").transform.Find("���Y��"))
        {
            dialogActive1 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg1.SetActive(true);
            StartCoroutine(TypeLine(dialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
        else
        {
            Debug.Log(gameObject);
            dialogActive2 = true; // ��ܹ�ܮ�
            dialogBox.SetActive(true);
            playerimg2.SetActive(true);
            StartCoroutine(TypeLine(nextDialogLines[currentLine])); // �}�Ҥ�r��X��{
        }
    }
}