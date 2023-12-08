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
    public GameObject Memory02;
    public GameObject Memory03;
    public GameObject doormemory02;
    public GameObject doormemory03;
    public GameObject boxopen;
    public GameObject electricalbox;
    public GameObject boneans;
    //public item useitem;

    public List<GameObject> slots = new List<GameObject>(); //管理生成20個slots
    public AudioSource box;
    public AudioSource memory;

    public bool WaterTank;
    public bool FireOven;
    public bool wrench;
    public bool magnet;
    //public bool Bonepuzzle;
    public Player player;
    void Update()
    {
        WaterTank = player.WaterTankOp;
        FireOven = player.FireOvenOp;
        wrench = player.wrench;
        magnet = player.magnet;
        //Bonepuzzle = player.Bonepuzzle;
    }
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

        if (itemCodeNum.text == "3" && FireOven == true)
        {
            Debug.Log("使用人骨");
            this.gameObject.SetActive(false);
            BonePuzzles.SetActive(true);
            itemCodeNum.text = "0";
        }

        if (itemCodeNum.text == "4" && WaterTank == true)
        {
            Debug.Log("使用鑰匙");
            this.gameObject.SetActive(false);
            boxopen.SetActive(true);
            box.Play();
            Memory02.SetActive(true);
            doormemory02.SetActive(true);
            memory.Play();
            OpenState.aquariumEverOpened = true;
            itemCodeNum.text = "0";
        }
        if (itemCodeNum.text == "4" && WaterTank == false)
        {
            itemInformation.text = "這裡好像用不到...";
            itemCodeNum.text = "0";
        }

        if (itemCodeNum.text == "5" && wrench == true)
        {
            Debug.Log("使用板手");
            this.gameObject.SetActive(false);
            electricalbox.SetActive(false);
            itemCodeNum.text = "0";
        }
        if (itemCodeNum.text == "5" && wrench == false)
        {
            itemInformation.text = "好像不能用在這裡...";
            itemCodeNum.text = "0";
        }

        if (itemCodeNum.text == "6" && magnet == true)
        {
            Debug.Log("使用磁鐵");
            this.gameObject.SetActive(false);
            Memory03.SetActive(true);
            doormemory03.SetActive(true);
            memory.Play();
            OpenState.tubEverOpend = true;
            itemCodeNum.text = "0";
        }
        if (itemCodeNum.text == "6" && magnet == false)
        {
            itemInformation.text = "好像不能用在這裡...";
            itemCodeNum.text = "0";
        }

        if (itemCodeNum.text == "7" && FireOven == true)
        {
            Debug.Log("使用骨頭圖");
            this.gameObject.SetActive(false);
            boneans.SetActive(true);
            itemCodeNum.text = "0";
        }
        if (itemCodeNum.text == "7" && FireOven == false)
        {
            itemInformation.text = "好像不能用在這裡...";
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
        for(int i = 0; i < instance.slotGrid.transform.childCount;i++)
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