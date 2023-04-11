using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventroyManager : MonoBehaviour
{
    static InventroyManager instance;

    public Inventroy myBag;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;
    public Text itemCodeNum;
    Text itemHold;
    public GameObject BonePuzzles;
    //public item useitem;

    public List<GameObject> slots = new List<GameObject>(); //管理生成20個slots

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void ReadCodeNum(string itemCodeNum)
    {
        instance.itemCodeNum.text = itemCodeNum;
    }

    public static void UpateItemInfo(string itemDescption)
    {
        instance.itemInformation.text = itemDescption;
    }

    public void BtnClick() //使用按鈕
    {
        if(itemCodeNum.text == "1")//偵測物品代號
        {
            Debug.Log("使用劍");
            this.gameObject.SetActive(false);
            itemCodeNum.text = "0";
        }
        if(itemCodeNum.text == "2")
        {
            Debug.Log("使用鞋子");
            this.gameObject.SetActive(false);
            itemCodeNum.text = "0";
        }
        if (itemCodeNum.text == "3")
        {
            Debug.Log("使用人骨");
            this.gameObject.SetActive(false);
            BonePuzzles.SetActive(true);
            itemCodeNum.text = "0";
        }
    }

    /*public static void CreateNewItem(item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/

    public static void RefreshItem()
    {
        for(int i = 0;i < instance.slotGrid.transform.childCount;i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for(int i = 0; i < instance.myBag.itemList.Count;i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }
}