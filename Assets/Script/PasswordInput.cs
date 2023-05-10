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

    //顯示密碼是否正確文字部分
    public float fadeTime = 1.0f; //淡出時間
    public Image Correctimage;
    public Image Wrongimage;
    float timer;
    public GameObject Safty;
    public bool isWrong;

    void Start()
    {
        // 限制輸入為整數
        inputField.contentType = InputField.ContentType.IntegerNumber;

        // 限制最大字符數量為 4
        inputField.characterLimit = 4;

        // 監聽值改變事件
        inputField.onValueChanged.AddListener(delegate { OnInputValueChange(); });

        //文字圖片事件
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
        // 如果輸入的字符數量超過 4，則截斷為 4 個字符
        if (inputField.text.Length > 4)
        {
            inputField.text = inputField.text.Substring(0, 4);
        }
    }

    public void CheckPassword()
    {
        if (inputField.text == correctPassword)
        {
            Debug.Log("正確");
            isCorrect = true;
            inputField.text = "";
            WaterTookKey.SetActive(true);
            Correctimage.CrossFadeAlpha(1.0f, 1.0f, false);
            Safty.SetActive(false);
            // TODO: unlock the game or perform other actions
        }
        else
        {
            Debug.Log("錯誤");
            isCorrect = false;
            inputField.text = "";
            Wrongimage.CrossFadeAlpha(1.0f, 0.1f, false);
            isWrong = true;
            // TODO: display an error message to the user
        }

    }
}
