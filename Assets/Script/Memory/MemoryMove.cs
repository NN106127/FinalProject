using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isButtonPressed;
    public bool isCheck;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (isButtonPressed == true)
        {
            this.gameObject.transform.position = mousePosition;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        if(otherRb != null)
        {
            Vector3 tempPosition = transform.position;
            transform.position = other.transform.position;
            other.transform.position = tempPosition;
        }
    }
}
