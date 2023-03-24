using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventroyManager : MonoBehaviour
{
    static InventroyManager instance;

    public Inventroy myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }



    public static void UpateItemInfo(string itemDescption)
    {
        instance.itemInformation.text = itemDescption;
    }

    public static void CreateNewItem(item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }

    public static void RefreshItem()
    {
        for(int i = 0;i < instance.slotGrid.transform.childCount;i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < instance.myBag.itemList.Count;i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
}
