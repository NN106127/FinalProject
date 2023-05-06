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

    void Start()
    {
        // �����J�����
        inputField.contentType = InputField.ContentType.IntegerNumber;

        // ����̤j�r�żƶq�� 4
        inputField.characterLimit = 4;

        // ��ť�ȧ��ܨƥ�
        inputField.onValueChanged.AddListener(delegate { OnInputValueChange(); });

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
            WaterTookKey.SetActive(true);
            // TODO: unlock the game or perform other actions
        }
        else
        {
            Debug.Log("���~");
            inputField.text = "";
            // TODO: display an error message to the user
        }
    }
}
