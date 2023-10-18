using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentOnOverlap : MonoBehaviour
{
    private SpriteRenderer sr;
    public float transparentAlpha = 0.5f;  // 設定半透明的透明度

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // 檢查是否為人物。確保您的人物有 "Player" 的 tag。
        {
            Color tempColor = sr.color;
            tempColor.a = transparentAlpha;
            sr.color = tempColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color tempColor = sr.color;
            tempColor.a = 1.0f;  // 設回完全不透明
            sr.color = tempColor;
        }
    }
}

