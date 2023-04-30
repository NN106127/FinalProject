using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PasswordInput : MonoBehaviour
{
    private InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CheckInput(eventData.position);
        }
    }

    private void CheckInput(Vector2 position)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(inputField.GetComponent<RectTransform>(), position, null, out Vector2 localPoint))
        {
            int num;
            if (int.TryParse(inputField.text, out num))
            {
                if (num >= 0 && num <= 9)
                {
                    inputField.text += num.ToString();
                }
            }
        }
    }
}
