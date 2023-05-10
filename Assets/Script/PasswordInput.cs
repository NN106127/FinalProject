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
    public bool isCorrect = false;

    //��ܱK�X�O�_���T��r����
    public float fadeTime = 1.0f;
    public GameObject Correct;
    public GameObject Wrong;
    public  float timer;
    public bool isClick = false;

    void Start()
    {
        // �����J�����
        inputField.contentType = InputField.ContentType.IntegerNumber;

        // ����̤j�r�żƶq�� 4
        inputField.characterLimit = 4;

        // ��ť�ȧ��ܨƥ�
        inputField.onValueChanged.AddListener(delegate { OnInputValueChange(); });

        Correct.SetActive(false);
        Wrong.SetActive(false);
    }

    private void Update()
    {
        if(isClick == true)
        {
            Debug.Log("isClick :" + isClick);

            if(isCorrect == true)
            {
                Correct.SetActive(true);
            }
            else
            {
                Wrong.SetActive(true);
                timer += Time.deltaTime;
                if (timer >= 1.0f)
                {
                    Wrong.SetActive(false);
                    timer = 0;
                }
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
            WaterTookKey.SetActive(true);
            isClick = true;
            // TODO: unlock the game or perform other actions
        }
        else
        {
            Debug.Log("���~");
            isCorrect = false;
            inputField.text = "";
            isClick = true;
            // TODO: display an error message to the user
        }

    }
}
