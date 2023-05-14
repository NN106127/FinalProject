using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PasswordInput : MonoBehaviour
{
    public string correctPassword = "1115";
    public InputField inputField;
    public GameObject WaterTookKey;
    public bool isCorrect;
    public GameObject open;
    public GameObject openbutton;
    public AudioSource rightopen;
    public AudioSource wrong;
    //��ܱK�X�O�_���T��r����
    //Image Correctimage;
    //Image Wrongimage;

    void Start()
    {
        // �����J�����
        inputField.contentType = InputField.ContentType.IntegerNumber;

        // ����̤j�r�żƶq�� 4
        inputField.characterLimit = 4;

        // ��ť�ȧ��ܨƥ�
        inputField.onValueChanged.AddListener(delegate { OnInputValueChange(); });

        //Correctimage.GetComponent<Image>();
        //Wrongimage.GetComponent<Image>();
    }

    private void Awake()
    {
       /* Correctimage.canvasRenderer.SetAlpha(0f);
        Wrongimage.canvasRenderer.SetAlpha(0f);*/
    }


    void OnInputValueChange()
    {
        // �p�G��J���r�żƶq�W�L 4�A�h�I�_�� 4 �Ӧr��
        if (inputField.text.Length > 4)
        {
            inputField.text = inputField.text.Substring(0, 4);
        }
    }

    public void CheckPassword()
    {
        if (inputField.text == correctPassword)
        {
            Debug.Log("���T");
            isCorrect = true;
            inputField.text = "";
            WaterTookKey.SetActive(true);
            open.SetActive(true);
            rightopen.Play();
            openbutton.SetActive(false);
            // TODO: unlock the game or perform other actions
        }
        else
        {
            Debug.Log("���~");
            wrong.Play();
            isCorrect = false;
            inputField.text = "";
            // TODO: display an error message to the user
        }

    }
}
