using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    private const string password = "1115";
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        //inputField = transform.parent.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (inputField.text == password)
        {
            Debug.Log("保险箱已打开！");
        }
        else
        {
            Debug.Log("密码错误！");
        }
        inputField.text = "";
    }
}
