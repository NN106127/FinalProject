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
        if (r0 >= 55 && r0 <= 65)
        {
            Vector3 pd1 = Bones[0].transform.position - Bones[1].transform.position;
            float r1 = Bones[1].transform.rotation.z;
            if ((pd1.x >= 100 && pd1.x <= 200) && (pd1.y >= 100 && pd1.y <= 200) && (r1 >= 55 && r1 <= 65))
            {
                PuzzlePass();
                return true;
            }
        }
        return false;
    }

    public void PuzzlePass()
    {

    }
}
