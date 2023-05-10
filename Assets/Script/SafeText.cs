using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeText : MonoBehaviour
{
    //��ܱK�X�O�_���T��r����
    public float fadeTime = 1.0f; //�H�X�ɶ�
    public Image Correctimage;
    public Image Wrongimage;
    public float timer;

    //public bool isCorrect;
    public bool isWrong;
    private PasswordInput passwordInput;
    private int W;

    // Start is called before the first frame update
    void Start()
    {
        //��r�Ϥ��ƥ�
        Correctimage.GetComponent<Image>();
        Wrongimage.GetComponent<Image>();
        Correctimage.canvasRenderer.SetAlpha(0f);
        Wrongimage.canvasRenderer.SetAlpha(0f);
        timer = 0f;

        passwordInput = FindObjectOfType<PasswordInput>();
        //bool value = passwordInput.isCorrect;
    }

    // Update is called once per frame
    void Update()
    {
        if(passwordInput.isCorrect == true)
        {
            Correctimage.CrossFadeAlpha(1.0f, 1.0f, false);
        }

        if(W == 0 && passwordInput.isCorrect == false)
        {
            Wrongimage.CrossFadeAlpha(1.0f, 0.1f, false);
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                Wrongimage.CrossFadeAlpha(0f, 0.5f, false);
                timer = 0;
                isWrong = false;
                W = W + 1;
            }
        }
    }
}
