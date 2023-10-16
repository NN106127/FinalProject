using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryConnect : MonoBehaviour
{
    private Rigidbody2D rb;
    public string  i = "" ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 检查碰撞的物体是否也有Rigidbody2D组件
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();

        if (other.gameObject.tag == "Memory")
        {
            // 将两个物体的位置对齐，你可以根据需要调整位置
            Vector3 newPosition = (transform.position + other.transform.position) / 2f;
            other.transform.position = newPosition;
            //Debug.Log("" + other.gameObject.name);
            i = other.gameObject.name;
        }
    }
}
