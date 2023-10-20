﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneConnected6 : MonoBehaviour
{
    private Rigidbody2D rb;
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

        if (other.gameObject.tag == "Bone6")
        {
            // 将两个物体的位置对齐，你可以根据需要调整位置
            Vector3 newPosition = (transform.position + other.transform.position) / 2f;
            other.transform.position = newPosition;
        }
    }
}