using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public item slotItem;
    public Image slotImage;
    public Text slotNum;

    public void ItemOnClick()
    {
        InventroyManager.UpateItemInfo(slotItem.itemInfo);
    }
}
