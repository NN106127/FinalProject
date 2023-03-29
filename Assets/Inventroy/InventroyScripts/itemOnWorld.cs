using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public item thisItem;
    public Inventroy playerInventroy;
    public GameObject textE;
    bool CanBePick;

    private void Update()
    {
        if (CanBePick)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddNewItem();
                Destroy(gameObject);
                Debug.Log("玩家已捡起");
                textE.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanBePick = true;
            textE.SetActive(true);
            Debug.Log("玩家与装备开始碰撞");
        }
        /*if(other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanBePick = false;
            textE.SetActive(false);
            Debug.Log("玩家与装备脱离碰撞");
        }
    }

    public void AddNewItem()
    {
        if (!playerInventroy.itemList.Contains(thisItem))
        {
            //playerInventroy.itemList.Add(thisItem);
            //InventroyManager.CreateNewItem(thisItem);
            for(int i = 0;i < playerInventroy.itemList.Count;i++)
            {
                if(playerInventroy.itemList[i] == null)
                {
                    playerInventroy.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventroyManager.RefreshItem();
    }
}
