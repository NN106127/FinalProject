using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject splashImage; // UI�Ϲ�����
    public float displayTime = 3.0f; // ��ܮɶ�
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowSplash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShowSplash()
    {
        splashImage.SetActive(true); // ���UI�Ϲ�����

        yield return new WaitForSeconds(displayTime); // ���ݤ@�q�ɶ�

        splashImage.SetActive(false); // ����UI�Ϲ�����
        Destroy(gameObject); // �R���ӹC������
    }
}
