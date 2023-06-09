﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    Rigidbody2D rb;
    Collider2D coll;

    public GameObject myBag;
    bool isOpen;

    public float speed;
    public float runSpeed;
    Vector2 movement;

    void Start()
    {

        // Animator
        myAnimator = GetComponent<Animator>();

        // Sprite
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        myAnimator.SetInteger("ani", 0);
        Movement();
        OpeMyBag();
    }

    void Movement()//移动
    {
        
        if(Input.GetKey(KeyCode.D))
        {
            mySpriteRenderer.flipX = false;
            myAnimator.SetInteger("ani", 1);
            movement.x = Input.GetAxisRaw("Horizontal");
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            mySpriteRenderer.flipX = true;
            myAnimator.SetInteger("ani", 1);
            movement.x = Input.GetAxisRaw("Horizontal");
            rb.MovePosition(rb.position - movement * -speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            myAnimator.SetInteger("ani", 2);
            rb.MovePosition(rb.position + movement * (speed + runSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            myAnimator.SetInteger("ani", 2);
            rb.MovePosition(rb.position - movement * -(speed + runSpeed) * Time.deltaTime);
        }


    }
    void OpeMyBag()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
