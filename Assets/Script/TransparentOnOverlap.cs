using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentOnOverlap : MonoBehaviour
{
    private SpriteRenderer sr;
    public float transparentAlpha = 0.5f;  // �]�w�b�z�����z����

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // �ˬd�O�_���H���C�T�O�z���H���� "Player" �� tag�C
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
            tempColor.a = 1.0f;  // �]�^�������z��
            sr.color = tempColor;
        }
    }
}

