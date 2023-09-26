using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberLock : MonoBehaviour
{
    //public Text passwordText; // 用于显示密码输入状态的文本
    private string password = "左右左左右"; // 设置正确的密码

    private string currentInput = ""; // 当前用户输入的数字串

    public Sprite[] imageOptions;  // 這是一個存儲不同圖像選項的數組
    private Image imageComponent;  // 用於引用Image元件的變量
    private int currentIndex = 0;  // 用於跟踪當前圖像的索引
    public List<Image> Images = new List<Image>();
    public List<Sprite> index = new List<Sprite>();
    public int Ans = 0;

    public void Start()
    {
        // 獲取Image元件的引用
        imageComponent = GetComponent<Image>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("" + currentInput);
            Debug.Log("" + password);
        }

        if (currentInput.Length == password.Length)
        {
            if (currentInput == password)
            {
                Images[0].sprite = index[1];
                Images[1].sprite = index[1];
                Images[2].sprite = index[1];
                Images[3].sprite = index[1];
                Images[4].sprite = index[1];
                //passwordText.text = "密码正确！"; // 输入正确的情况
                Ans = -1;
            }
            if (currentInput != password)
            {
                Images[0].sprite = index[2];
                Images[1].sprite = index[2];
                Images[2].sprite = index[2];
                Images[3].sprite = index[2];
                Images[4].sprite = index[2];
                //passwordText.text = "密码错误！"; // 输入错误的情况
                currentInput = ""; // 重置输入
                Ans = 6;
            }
        }

        if (Ans == 0)
        {
            Images[0].sprite = index[0];
            Images[1].sprite = index[0];
            Images[2].sprite = index[0];
            Images[3].sprite = index[0];
            Images[4].sprite = index[0];
        }
        if (Ans == 1)
        {
            Images[0].sprite = index[1];
            Images[1].sprite = index[0];
            Images[2].sprite = index[0];
            Images[3].sprite = index[0];
            Images[4].sprite = index[0];
        }
        if (Ans == 2)
        {
            Images[1].sprite = index[1];
        }
        if (Ans == 3)
        {
            Images[2].sprite = index[1];
        }
        if (Ans == 4)
        {
            Images[3].sprite = index[1];
        }
        if (Ans == 5)
        {
            Images[4].sprite = index[1];
        }
        if (Ans >= 7)
        {
            Ans = 1;
        }
    }


    public void OnNumberButtonClick(string number)
    {
        currentInput += number;

        // 更新UI显示
        //passwordText.text = "当前输入：" + currentInput;
    }

    public void OnClick()
    {
        Ans += 1;
    }
}
