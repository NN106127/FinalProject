using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour
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

    public AudioSource walk;
    public AudioSource run;

    public bool WaterTankOp;
    public bool FireOvenOp;
    public bool wrench;
    public bool magnet;
    //public bool Bonepuzzle;
    public bool isDead;
    public bool isMovementEnabled = true;
    void Start()
    {
        isDead = false;
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
        //myAnimator.SetInteger("ani", 0);
        Movement();
        OpeMyBag();
        
    }

    void Movement()//移动
    {
        if (isMovementEnabled)
        {
            if (!isDead)
            {
                myAnimator.SetBool("idle", true);
                myAnimator.SetBool("dead", false);
            }

            myAnimator.SetBool("run", false);
            myAnimator.SetBool("walk", false);
            if (Input.GetKey(KeyCode.D))
            {
                mySpriteRenderer.flipX = false;
                //myAnimator.SetInteger("ani", 1);
                myAnimator.SetBool("walk", true);
                myAnimator.SetBool("idle", false);
                myAnimator.SetBool("run", false);
                movement.x = Input.GetAxisRaw("Horizontal");
                rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.A))
            {
                mySpriteRenderer.flipX = true;
                //myAnimator.SetInteger("ani", 1);
                myAnimator.SetBool("walk", true);
                myAnimator.SetBool("idle", false);
                myAnimator.SetBool("run", false);
                movement.x = Input.GetAxisRaw("Horizontal");
                rb.MovePosition(rb.position - movement * -speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {
                //myAnimator.SetInteger("ani", 2);
                myAnimator.SetBool("run", true);
                myAnimator.SetBool("idle", false);
                myAnimator.SetBool("walk", false);
                rb.MovePosition(rb.position + movement * (speed + runSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
            {
                //myAnimator.SetInteger("ani", 2);
                myAnimator.SetBool("run", true);
                myAnimator.SetBool("idle", false);
                myAnimator.SetBool("walk", false);
                rb.MovePosition(rb.position - movement * -(speed + runSpeed) * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                walk.Play();
                run.Stop();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                walk.Stop();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                walk.Play();
                run.Stop();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                walk.Stop();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift)&& Input.GetKey(KeyCode.A))
            {
                run.Play();
                walk.Stop();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {
                run.Play();
                walk.Stop();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
            {
                walk.Play();
                run.Stop();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {
                walk.Play();
                run.Stop();
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
            {
                run.Play();
                walk.Stop();
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            {
                run.Play();
                walk.Stop();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                run.Stop();
            }

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
    public void OnClick()
    {
        isOpen = !isOpen;
        myBag.SetActive(isOpen);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "WaterTank")
        {
            WaterTankOp = true;
        }

        if (other.gameObject.tag == "FireOven")
        {
            FireOvenOp = true;
        }
        if (other.gameObject.tag == "wrench")
        {
            Debug.Log(other.tag);
            wrench = true;
        }
        if (other.gameObject.tag == "magnet")
        {
            magnet = true;
        }

        if (other.gameObject.tag == "Ghost")
        {
            isDead = true;
            myAnimator.SetBool("idle", false);
            myAnimator.SetBool("walk", false);
            myAnimator.SetBool("run", false);
            myAnimator.SetBool("dead", true);
        }
        /*if (other.gameObject.tag == "Bonepuzzle")
        {
            Bonepuzzle = true;
        }*/

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "WaterTank")
        {
            WaterTankOp = false;
        }

        if (other.gameObject.tag == "FireOven")
        {
            FireOvenOp = false;
        }
        if (other.gameObject.tag == "wrench")
        {
            wrench = false;
        }
        if (other.gameObject.tag == "magnet")
        {
            magnet = false;
        }
        /*if (other.gameObject.tag == "Bonepuzzle")
        {
            Bonepuzzle = false;
        }*/
    }
}
