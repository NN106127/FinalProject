using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class NumBtn : MonoBehaviour
{
    public InputField inputField;
    private string input = "";

    public void AddNumber(int number)
    {
        input += number.ToString();
        inputField.text = input;
    }

    public void ResPassWord()
    {
        input = "";
    }

}
