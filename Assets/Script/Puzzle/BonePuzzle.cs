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
            Vector3 Cr1 = Bones[0].transform.localPosition = new Vector3(-116, 98, 0);
            Quaternion Ro1 = Bones[0].transform.localRotation = Quaternion.Euler(0, 0, 60);
            Vector3 Cr2 = Bones[1].transform.localPosition = new Vector3(-78, 5, 0);
            Quaternion Ro2 = Bones[1].transform.localRotation = Quaternion.Euler(0, 0, 35);
            Vector3 Cr3 = Bones[2].transform.localPosition = new Vector3(-116, 98, 0);
            Quaternion Ro3 = Bones[2].transform.localRotation = Quaternion.Euler(0, 0, -105);
            Vector3 Cr4 = Bones[3].transform.localPosition = new Vector3(-130, 5, 0);
            Quaternion Ro4 = Bones[3].transform.localRotation = Quaternion.Euler(0, 0, 75);
            Vector3 Cr5 = Bones[4].transform.localPosition = new Vector3(32, 49, 0);
            Quaternion Ro5 = Bones[4].transform.localRotation = Quaternion.Euler(0, 0, 65);
            Vector3 Cr6 = Bones[5].transform.localPosition = new Vector3(32, -29, 0);
            Quaternion Ro6 = Bones[5].transform.localRotation = Quaternion.Euler(0, 0, 0);
            Vector3 Cr7 = Bones[6].transform.localPosition = new Vector3(-2, 72, 0);
            Quaternion Ro7 = Bones[6].transform.localRotation = Quaternion.Euler(0, 0, -90);
            Vector3 Cr8 = Bones[7].transform.localPosition = new Vector3(-55, -93, 0);
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
        if (r0 >= -0.4 && r0 <= -0.2)
        {
            Debug.Log("0");
            Vector3 pd1 = Bones[0].transform.position - Bones[1].transform.position;
            float r1 = Bones[1].transform.rotation.z;
            if ((pd1.x >= -128 && pd1.x <= -28) && (pd1.y >= -45 && pd1.y <= 55) && (r1 >= -0.4 && r1 <= -0.2))
            {
                Debug.Log("1");
                Vector3 pd2 = Bones[0].transform.position - Bones[2].transform.position;
                float r2 = Bones[2].transform.rotation.z;
                if ((pd2.x >= -166 && pd2.x <= -66) && (pd2.y >= 48 && pd2.y <= 148) && (r2 >= -0.9 && r2 <= -0.7))
                {
                    Debug.Log("2");
                    Vector3 pd3 = Bones[0].transform.position - Bones[3].transform.position;
                    float r3 = Bones[3].transform.rotation.z;
                    if ((pd3.x >= -180 && pd3.x <= -80) && (pd3.y >= -45 && pd3.y <= 55) && (r3 >= -0.7 && r3 <= -0.5))
                    {
                        Debug.Log("3");
                        Vector3 pd4 = Bones[0].transform.position - Bones[4].transform.position;
                        float r4 = Bones[4].transform.rotation.z;
                        if ((pd4.x >= -18 && pd4.x <= 82) && (pd4.y >= -1 && pd4.y <= 99) && (r4 >= 0.4 && r4 <= 0.6))
                        {
                            Debug.Log("4");
                            Vector3 pd5 = Bones[0].transform.position - Bones[5].transform.position;
                            float r5 = Bones[5].transform.rotation.z;
                            if ((pd5.x >= -18 && pd5.x <= 82) && (pd5.y >= -79 && pd5.y <= 21) && (r5 >= -1 && r5 <= 1))
                            {
                                Debug.Log("5");
                                Vector3 pd6 = Bones[0].transform.position - Bones[6].transform.position;
                                float r6 = Bones[6].transform.rotation.z;
                                if ((pd6.x >= -52 && pd6.x <= 48) && (pd6.y >= 22 && pd6.y <= 122) && (r6 >= 0.6 && r6 <= 0.8))
                                {
                                    Debug.Log("6");
                                    Vector3 pd7 = Bones[0].transform.position - Bones[7].transform.position;
                                    float r7 = Bones[7].transform.rotation.z;
                                    if ((pd7.x >= -105 && pd7.x <= -5) && (pd7.y >= -143 && pd7.y <= -43) && (r7 >= -0.9 && r7 <= -0.7))
                                    {
                                        Debug.Log("7");
                                        PuzzlePass();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public void PuzzlePass()
    {
        Debug.Log("CLEAR");
        Memory01.SetActive(true);
    }
}
