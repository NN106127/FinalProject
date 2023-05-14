using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonePuzzle : MonoBehaviour
{
    public List<Bone> Bones = new List<Bone>();
    //public Bone ActiveBone;
    float RotationSpeed = 5;
    public GameObject Memory01;
    public Bone[] bone;
    public Text pluzztext;
    public AudioSource memory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CheckMatch();
        }
        foreach (Bone bones in bone)
        {
            bool isCheck = bones.isButtonPressed;
            if (isCheck == true)
            {
                //CheckMatch();
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PuzzlePass();
        }

        if (Input.GetKey(KeyCode.F2))
        {
            Vector3 Cr1 = Bones[0].transform.localPosition = new Vector3(-74, 78, 0);
            Quaternion Ro1 = Bones[0].transform.localRotation = Quaternion.Euler(0, 0, 60);
            Vector3 Cr2 = Bones[1].transform.localPosition = new Vector3(7, 56, 0);
            Quaternion Ro2 = Bones[1].transform.localRotation = Quaternion.Euler(0, 0, 35);
            Vector3 Cr3 = Bones[2].transform.localPosition = new Vector3(48, -12, 0);
            Quaternion Ro3 = Bones[2].transform.localRotation = Quaternion.Euler(0, 0, -105);
            Vector3 Cr4 = Bones[3].transform.localPosition = new Vector3(62, 72, 0);
            Quaternion Ro4 = Bones[3].transform.localRotation = Quaternion.Euler(0, 0, 75);
            Vector3 Cr5 = Bones[4].transform.localPosition = new Vector3(-101, 42, 0);
            Quaternion Ro5 = Bones[4].transform.localRotation = Quaternion.Euler(0, 0, 65);
            Vector3 Cr6 = Bones[5].transform.localPosition = new Vector3(-115, 100, 0);
            Quaternion Ro6 = Bones[5].transform.localRotation = Quaternion.Euler(0, 0, 0);
            Vector3 Cr7 = Bones[6].transform.localPosition = new Vector3(-60, 1, 0);
            Quaternion Ro7 = Bones[6].transform.localRotation = Quaternion.Euler(0, 0, -90);
            Vector3 Cr8 = Bones[7].transform.localPosition = new Vector3(-40, 164, 0);
            Quaternion Ro8 = Bones[7].transform.localRotation = Quaternion.Euler(0, 0, -105);
            CheckMatch();
        }
    }

    public bool CheckMatch()
    {
        foreach (Bone bone in Bones)
        {
            Debug.Log("-----------------");
            Debug.Log(bone.name);
            Vector3 positionDiff = Bones[0].transform.position - bone.transform.position;
            Debug.Log(positionDiff.x + ", " + positionDiff.y + ", " + positionDiff.z);
            Debug.Log("rz: " + bone.transform.rotation.z);
        }

        float r0 = Bones[0].transform.rotation.z;
        if (r0 >= 0.3 && r0 <= 0.7)
        {
            Debug.Log("0");
            Vector3 pd1 = Bones[0].transform.position - Bones[1].transform.position;
            float r1 = Bones[1].transform.rotation.z;
            if ((pd1.x >= -181 && pd1.x <= 81) && (pd1.y >= -78 && pd1.y <= 122) && (r1 >= 0.1 && r1 <= 0.5))
            {
                Debug.Log("1");
                Vector3 pd2 = Bones[0].transform.position - Bones[2].transform.position;
                float r2 = Bones[2].transform.rotation.z;
                if ((pd2.x >= -222 && pd2.x <= -22) && (pd2.y >= -10 && pd2.y <= 190) && (r2 >= -0.9 && r2 <= -0.5))
                {
                    Debug.Log("2");
                    Vector3 pd3 = Bones[0].transform.position - Bones[3].transform.position;
                    float r3 = Bones[3].transform.rotation.z;
                    if ((pd3.x >= -236 && pd3.x <= -36) && (pd3.y >= -94 && pd3.y <= 106) && (r3 >= 0.4 && r3 <= 0.8))
                    {
                        Debug.Log("3");
                        Vector3 pd4 = Bones[0].transform.position - Bones[4].transform.position;
                        float r4 = Bones[4].transform.rotation.z;
                        if ((pd4.x >= -73 && pd4.x <= 127) && (pd4.y >= -64 && pd4.y <= 136) && (r4 >= 0.3 && r4 <= 0.7))
                        {
                            Debug.Log("4");
                            Vector3 pd5 = Bones[0].transform.position - Bones[5].transform.position;
                            float r5 = Bones[5].transform.rotation.z;
                            if ((pd5.x >= -59 && pd5.x <= 141) && (pd5.y >= -122 && pd5.y <= 78) && (r5 >= -1.1 && r5 <= 1.1))
                            {
                                Debug.Log("5");
                                Vector3 pd6 = Bones[0].transform.position - Bones[6].transform.position;
                                float r6 = Bones[6].transform.rotation.z;
                                if ((pd6.x >= -114 && pd6.x <= 86) && (pd6.y >= -23 && pd6.y <= 177) && (r6 >= -0.9 && r6 <= -0.5))
                                {
                                    Debug.Log("6");
                                    Vector3 pd7 = Bones[0].transform.position - Bones[7].transform.position;
                                    float r7 = Bones[7].transform.rotation.z;
                                    if ((pd7.x >= -172 && pd7.x <= 28) && (pd7.y >= -193 && pd7.y <= 7) && (r7 >= -0.9 && r7 <= -0.7))
                                    {
                                        Debug.Log("7");
                                        PuzzlePass();
                                        pluzztext.text = "";
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        pluzztext.text = "好像哪裡不太對";
        return false;
    }
    public void OnPluzzCheck()
    {
        CheckMatch();
    }

    public void PuzzlePass()
    {
        Debug.Log("CLEAR");
        memory.Play();
        Memory01.SetActive(true);
    }
}
