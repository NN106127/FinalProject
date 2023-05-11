using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class NumBtn : MonoBehaviour
{
    public InputField inputField;
    private string input = "";
    public AudioSource m_audio;

    public void AddNumber(int number)
    {
        input += number.ToString();
        inputField.text = input;
        m_audio.Play();
    }

    public void ResPassWord()
    {
        input = "";
    }

}
