﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSource : MonoBehaviour
{
    public Sprite[] imageOptions;  // 這是一個存儲不同圖像選項的數組
    private Image imageComponent;  // 用於引用Image元件的變量
    public int currentIndex = 0;  // 用於跟踪當前圖像的索引
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        // 獲取Image元件的引用
        imageComponent = GetComponent<Image>();

        // 初始顯示第一個圖像
        if (imageOptions.Length > 0)
        {
            imageComponent.sprite = imageOptions[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        imageComponent.sprite = imageOptions[currentIndex];
        if (isActive == true)
        {
            currentIndex = 1;
        }
        else
        {
            currentIndex = 0;
        }
    }

    public void Onclick()
    {
        isActive = !isActive;
    }
}