using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    public float smothing;
    public Vector2 minposition;
    public Vector2 maxposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minposition.x, maxposition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minposition.y, maxposition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smothing);
            }
        }
    }
    public void SetCamPosLimit(Vector2 minpos,Vector2 maxpos )
    {
        minposition = minpos;
        maxposition = maxpos;
    }
}
