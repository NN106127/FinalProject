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

    //陪ボ盞絏琌タ絋ゅ场だ
    //Image Correctimage;
    //Image Wrongimage;

    void Start()
    {
        // 块俱计
        inputField.contentType = InputField.ContentType.IntegerNumber;

        // 程才计秖 4
        inputField.characterLimit = 4;

        // 菏钮э跑ㄆン
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
        // 狦块才计秖禬筁 4玥篒耞 4 才
        if (inputField.text.Length > 4)
        {
            inputField.text = inputField.text.Substring(0, 4);
        }
    }

    public void CheckPassword()
    {
        if (inputField.text == correctPassword)
        {
            Debug.Log("タ絋");
            isCorrect = true;
            inputField.text = "";
            WaterTookKey.SetActive(true);
            // TODO: unlock the game or perform other actions
        }
        else
        {
            Debug.Log("岿粇");
            isCorrect = false;
            inputField.text = "";
            // TODO: display an error message to the user
        }

    }
}
