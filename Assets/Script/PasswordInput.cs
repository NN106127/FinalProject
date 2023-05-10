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

    //��ܱK�X�O�_���T��r����
    public float fadeTime = 1.0f; //�H�X�ɶ�
    public Image Correctimage;
    public Image Wrongimage;
    float timer;
    public GameObject Safty;
    public bool isWrong;

    void Start()
    {
        // �����J�����
        inputField.contentType = InputField.ContentType.IntegerNumber;

        // ����̤j�r�żƶq�� 4
        inputField.characterLimit = 4;

        // ��ť�ȧ��ܨƥ�
        inputField.onValueChanged.AddListener(delegate { OnInputValueChange(); });

        //��r�Ϥ��ƥ�
        Correctimage.GetComponent<Image>();
        Wrongimage.GetComponent<Image>();
        Correctimage.canvasRenderer.SetAlpha(0f);
        Wrongimage.canvasRenderer.SetAlpha(0f);
        timer = 0f;
    }

    void Update()
    {
        if(isWrong == true)
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                Wrongimage.CrossFadeAlpha(0f, 0.5f, false);
                timer = 0;
                isWrong = false;
            }
        }
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
            Correctimage.CrossFadeAlpha(1.0f, 1.0f, false);
            Safty.SetActive(false);
            // TODO: unlock the game or perform other actions
        }
        else
        {
            Debug.Log("���~");
            isCorrect = false;
            inputField.text = "";
            Wrongimage.CrossFadeAlpha(1.0f, 0.1f, false);
            isWrong = true;
            // TODO: display an error message to the user
        }

    }
}
