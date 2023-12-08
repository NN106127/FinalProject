using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : MonoBehaviour
{
    public static bool wardrobeEverOpened; //衣櫃
    public static bool aquariumEverOpened; //水族箱 
    public static bool fridgeEverOpened;   //冰箱 
    public static bool ovenEverOpened;     //烤箱
    public static bool tipsEverOpend;      //開頭
    public static bool calendarEverOpend;  //月曆
    public static bool mirrorEverOpend; //鏡子
    public static bool dollEverOpend; //玩偶
    public static bool electricalboxEverOpend; //電箱
    public static bool tubEverOpend; //浴缸
    public static bool doorEverOpend; //門
    public static bool cabinetEverOpend; //廚房櫃子
    public static bool cupboardEverOpend; //地下室櫃子
    public static bool ResEverOpend; //重生
    public static bool ch2EverOpend; //地下室人
    public static bool ch3EverOpend; //浴室人
    public static void Initial()
    {
        wardrobeEverOpened = false;
        aquariumEverOpened = false;
        fridgeEverOpened = false;
        ovenEverOpened = false;
        tipsEverOpend = false;
        calendarEverOpend = false;
        mirrorEverOpend = false;
        dollEverOpend = false;
        electricalboxEverOpend = false;
        tubEverOpend = false;
        doorEverOpend = false;
        cabinetEverOpend = false;
        cupboardEverOpend = false;
        ResEverOpend = false;
        ch2EverOpend = false;
        ch3EverOpend = false;
    }
}
