using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnGrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originaParent;
    public Inventroy myBag;
    private int currentItemID;  //��e���~ID

    public void OnBeginDrag(PointerEventData eventData)
    {
        originaParent = transform.parent;
        currentItemID = originaParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name); //��X���з�e��m��C�@��Ĳ�I�쪫�骺�W�r
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "item Image" || eventData.pointerCurrentRaycast.gameObject.name == "number")  //�P�_�U������W�r�O: item Image ���򤬴���m
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //itemList�����~�x�s��m����
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originaParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originaParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
            {
                //�_�h�������b�˴��쪺Slot�U��
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //itemList�����~'�x�s��m���� 
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemList[currentItemID];
                //�ѨM��b���m���~�q�I�]����
                if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID != currentItemID)
                    myBag.itemList[currentItemID] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }

        else
        //��L��m���k��
        transform.SetParent(originaParent);
        transform.position = originaParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
