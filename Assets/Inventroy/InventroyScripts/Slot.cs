using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID; //�Ů�ID 
    public item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;
    string slotCN;

    public GameObject itemInSlot;

    public void ItemOnClick()
    {
        InventroyManager.UpateItemInfo(slotInfo);
        InventroyManager.ReadCodeNum(slotCN);//�쪫�~�N��
        Debug.Log("" + slotCN);
    }

    public void SetupSlot(item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
        slotCN = item.itemCodeNum;
    }
}
