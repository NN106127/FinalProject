using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool CanMove;
    public delegate void BoneEventArg(Bone bone);
    public event BoneEventArg MouseDown;
    public event BoneEventArg MouseUp;
    public bool isButtonPressed;
    public bool isCheck;
    float RotationSpeed = 5;

    void Start()
    {
        BonePuzzle bonePuzzle = GetComponent<BonePuzzle>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (isButtonPressed == true)
        {
            this.gameObject.transform.position = mousePosition;
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 0, -RotationSpeed);
                //CheckMatch();
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, 0, RotationSpeed);
                //CheckMatch();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
        isCheck = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
        isCheck = true;
    }
}
