using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneOutofRange : MonoBehaviour
{
    public GameObject[] Bone;
    Vector3 Bone01,Bone02, Bone03, Bone04, Bone05, Bone06, Bone07, Bone08;
    bool Bo1,Bo2,Bo3,Bo4,Bo5,Bo6,Bo7,Bo8;
    // Start is called before the first frame update
    void Start()
    {
        Bone01 = Bone[0].transform.localPosition;
        Bone02 = Bone[1].transform.localPosition;
        Bone03 = Bone[2].transform.localPosition;
        Bone04 = Bone[3].transform.localPosition;
        Bone05 = Bone[4].transform.localPosition;
        Bone06 = Bone[5].transform.localPosition;
        Bone07 = Bone[6].transform.localPosition;
        Bone08 = Bone[7].transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Bo1 == true)
        {
            Bone[0].transform.localPosition = Bone01;
        }

        if (Bo2 == true)
        {
            Bone[1].transform.localPosition = Bone02;
        }

        if (Bo3 == true)
        {
            Bone[2].transform.localPosition = Bone03;
        }

        if (Bo4 == true)
        {
            Bone[3].transform.localPosition = Bone04;
        }

        if (Bo5 == true)
        {
            Bone[4].transform.localPosition = Bone05;
        }

        if (Bo6 == true)
        {
            Bone[5].transform.localPosition = Bone06;
        }

        if (Bo7 == true)
        {
            Bone[6].transform.localPosition = Bone07;
        }

        if (Bo8 == true)
        {
            Bone[7].transform.localPosition = Bone08;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bone1")
        {
            Bo1 = false;
        }

        if (collision.gameObject.tag == "Bone2")
        {
            Bo2 = false;
        }

        if (collision.gameObject.tag == "Bone3")
        {
            Bo3 = false;
        }

        if (collision.gameObject.tag == "Bone4")
        {
            Bo4 = false;
        }

        if (collision.gameObject.tag == "Bone5")
        {
            Bo5 = false;
        }

        if (collision.gameObject.tag == "Bone6")
        {
            Bo6 = false;
        }

        if (collision.gameObject.tag == "Bone7")
        {
            Bo7 = false;
        }

        if (collision.gameObject.tag == "Bone8")
        {
            Bo8 = false;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bone1")
        {
            Bo1 = true;
        }

        if (collision.gameObject.tag == "Bone2")
        {
            Bo2 = true;
        }

        if (collision.gameObject.tag == "Bone3")
        {
            Bo3 = true;
        }

        if (collision.gameObject.tag == "Bone4")
        {
            Bo4 = true;
        }

        if (collision.gameObject.tag == "Bone5")
        {
            Bo5 = true;
        }

        if (collision.gameObject.tag == "Bone6")
        {
            Bo6 = true;
        }

        if (collision.gameObject.tag == "Bone7")
        {
            Bo7 = true;
        }

        if (collision.gameObject.tag == "Bone8")
        {
            Bo8 = true;
        }
    }
}
