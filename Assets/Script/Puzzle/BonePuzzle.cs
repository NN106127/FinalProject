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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PuzzlePass();
        }

        if (Input.GetKey(KeyCode.F2))
        {
            Vector3 Cr1 = Bones[0].transform.localPosition = new Vector3(1, 164, 0);
            Quaternion Ro1 = Bones[0].transform.localRotation = Quaternion.Euler(0, 0, 60);
            Vector3 Cr2 = Bones[1].transform.localPosition = new Vector3(90, 145, 0);
            Quaternion Ro2 = Bones[1].transform.localRotation = Quaternion.Euler(0, 0, 35);
            Vector3 Cr3 = Bones[2].transform.localPosition = new Vector3(131, 81, 0);
            Quaternion Ro3 = Bones[2].transform.localRotation = Quaternion.Euler(0, 0, -105);
            Vector3 Cr4 = Bones[3].transform.localPosition = new Vector3(146, 148, 0);
            Quaternion Ro4 = Bones[3].transform.localRotation = Quaternion.Euler(0, 0, 75);
            Vector3 Cr5 = Bones[4].transform.localPosition = new Vector3(-36, 118, 0);
            Quaternion Ro5 = Bones[4].transform.localRotation = Quaternion.Euler(0, 0, 65);
            Vector3 Cr6 = Bones[5].transform.localPosition = new Vector3(-55, 175, 0);
            Quaternion Ro6 = Bones[5].transform.localRotation = Quaternion.Euler(0, 0, 0);
            Vector3 Cr7 = Bones[6].transform.localPosition = new Vector3(18, 100, 0);
            Quaternion Ro7 = Bones[6].transform.localRotation = Quaternion.Euler(0, 0, -90);
            Vector3 Cr8 = Bones[7].transform.localPosition = new Vector3(32, 260, 0);
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
        if (r0 >= 0.4 && r0 <= 0.6)
        {
            Vector3 pd1 = Bones[0].transform.position - Bones[1].transform.position;
            float r1 = Bones[1].transform.rotation.z;
            if ((pd1.x >= -139 && pd1.x <= -39) && (pd1.y >= -49 && pd1.y <= 69) && (r1 >= 0 && r1 <= 0.6))
            {
                Vector3 pd2 = Bones[0].transform.position - Bones[2].transform.position;
                float r2 = Bones[2].transform.rotation.z;
                if ((pd2.x >= -180 && pd2.x <= -80) && (pd2.y >= 31 && pd2.y <= 131) && (r2 >= -1 && r2 <= -0.2))
                {
                    Vector3 pd3 = Bones[0].transform.position - Bones[3].transform.position;
                    float r3 = Bones[3].transform.rotation.z;
                    if ((pd3.x >= -195 && pd3.x <= -95) && (pd3.y >= -46 && pd3.y <= 66) && (r3 >= 0.2 && r3 <= 0.9))
                    {
                        Vector3 pd4 = Bones[0].transform.position - Bones[4].transform.position;
                        float r4 = Bones[4].transform.rotation.z;
                        if ((pd4.x >= -27 && pd4.x <= 87) && (pd4.y >= -16 && pd4.y <= 96) && (r4 >= 0.2 && r4 <= 0.9))
                        {
                            Vector3 pd5 = Bones[0].transform.position - Bones[5].transform.position;
                            float r5 = Bones[5].transform.rotation.z;
                            if ((pd5.x >= 6 && pd5.x <= 106) && (pd5.y >= -61 && pd5.y <= 41) && (r5 >= -1 && r5 <= 1))
                            {
                                Vector3 pd6 = Bones[0].transform.position - Bones[6].transform.position;
                                float r6 = Bones[6].transform.rotation.z;
                                if ((pd6.x >= -67 && pd6.x <= 47) && (pd6.y >= 14 && pd6.y <= 114) && (r6 >= -0.8 && r6 <= -0.6))
                                {
                                    Vector3 pd7 = Bones[0].transform.position - Bones[7].transform.position;
                                    float r7 = Bones[7].transform.rotation.z;
                                    if ((pd7.x >= -92 && pd7.x <= 12) && (pd7.y >= -137 && pd7.y <= -37) && (r7 >= -0.8 && r7 <= -0.6))
                                    {
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
