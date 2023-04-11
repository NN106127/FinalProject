using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoneRoation : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    bool CanMove;
    float RotationSpeed = 5;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("" + CanMove);
            if(CanMove == true)
            MoveBone();
            if (Input.GetKeyDown(KeyCode.E))
                this.gameObject.transform.Rotate(0,0,RotationSpeed);
            if (Input.GetKeyDown(KeyCode.Q))
                this.gameObject.transform.Rotate(0, 0, -RotationSpeed);
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

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
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
    }
}
