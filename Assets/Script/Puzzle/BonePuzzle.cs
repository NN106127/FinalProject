using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePuzzle : MonoBehaviour
{
    public List<Bone> Bones = new List<Bone>();
    public Bone ActiveBone;
    float RotationSpeed = 5;


    public void Start()
    {
        foreach(Bone bone in Bones)
        {
            //Debug.Log(bone.name);
            bone.MouseDown += Bone_MouseDown;
            bone.MouseUp += Bone_MouseUp;
        }
    }

    private void Bone_MouseUp(Bone bone)
    {
        CheckMatch();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActiveBone.transform.Rotate(0, 0, -RotationSpeed);
            CheckMatch();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActiveBone.transform.Rotate(0, 0, RotationSpeed);
            CheckMatch();
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            PuzzlePass();
        }
    }

    private void Bone_MouseDown(Bone bone)
    {
       //Debug.Log(bone.name);
        ActiveBone = bone;
    }

    public bool CheckMatch()
    {
        foreach (Bone bone in Bones)
        {
            Debug.Log("-----------------");
            Debug.Log(bone.name);
            Vector3 positionDiff = Bones[0].transform.position - bone.transform.position;
            Debug.Log(positionDiff.x + ", " +positionDiff.y + ", " + positionDiff.z);
            Debug.Log("rz: " + bone.transform.rotation.z);
        }

        float r0 = Bones[0].transform.rotation.z;
        if (r0 >= 0.2 && r0 <= 0.4)
        {
            Vector3 pd1 = Bones[0].transform.position - Bones[1].transform.position;
            float r1 = Bones[1].transform.rotation.z;
            if ((pd1.x >= -139 && pd1.x <= -129) && (pd1.y >= -10 && pd1.y <= 10) && (r1 >= 0.2 && r1 <= 0.4))
            {
                Vector3 pd2 = Bones[0].transform.position - Bones[2].transform.position;
                float r2 = Bones[2].transform.rotation.z;
                if ((pd2.x >= -211 && pd2.x <= -191) && (pd2.y >= 97 && pd2.y <= 117) && (r2 >= -0.8 && r2 <= -0.6))
                {
                    Vector3 pd3 = Bones[0].transform.position - Bones[3].transform.position;
                    float r3 = Bones[3].transform.rotation.z;
                    if ((pd3.x >= -216 && pd3.x <= -196) && (pd3.y >= -38 && pd3.y <= -18) && (r3 >= 0.5 && r3 <= 0.7))
                    {
                        Vector3 pd4 = Bones[0].transform.position - Bones[4].transform.position;
                        float r4 = Bones[4].transform.rotation.z;
                        if ((pd4.x >= 22 && pd4.x <= 42) && (pd4.y >= 27 && pd4.y <= 47) && (r4 >= 0.3 && r4 <= 0.5))
                        {
                            Vector3 pd5 = Bones[0].transform.position - Bones[5].transform.position;
                            float r5 = Bones[5].transform.rotation.z;
                            if ((pd5.x >= 16 && pd5.x <= 36) && (pd5.y >= -78 && pd5.y <= -58) && (r5 >= -1 && r5 <= 1))
                            {
                                Vector3 pd6 = Bones[0].transform.position - Bones[6].transform.position;
                                float r6 = Bones[6].transform.rotation.z;
                                if ((pd6.x >= -38 && pd6.x <= -18) && (pd6.y >= 77 && pd6.y <= 97) && (r6 >= -0.8 && r6 <= -0.6))
                                {
                                    Vector3 pd7 = Bones[0].transform.position - Bones[7].transform.position;
                                    float r7 = Bones[7].transform.rotation.z;
                                    if ((pd7.x >= -67    && pd7.x <= -47) && (pd7.y >= -164 && pd7.y <= -144) && (r7 >= -0.8 && r7 <= -0.6))
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
    }
}
