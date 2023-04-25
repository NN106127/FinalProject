using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bone : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    bool CanMove;
    public delegate void BoneEventArg(Bone bone);
    public event BoneEventArg MouseDown;
    public event BoneEventArg MouseUp;


    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(CanMove == true)
            MoveBone();
        }
    }

    public void MoveBone()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            raycastResults[0].gameObject.transform.position = Input.mousePosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //MouseDown?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("1:"+eventData.pointerCurrentRaycast.gameObject.name);
        MouseDown(this);
        if (eventData.pointerCurrentRaycast.gameObject.name == "BonePuzzle")
        {
            CanMove = false;
        }
        else
            CanMove = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CanMove = false;
        MouseUp(this);
    }
}
