using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : MonoBehaviour
{
    public static bool wardrobeEverOpened; //���d
    public static bool aquariumEverOpened; //���ڽc 
    public static bool fridgeEverOpened;   //�B�c 
    public static bool ovenEverOpened;     //�N�c
    public static bool tipsEverOpend;      //�}�Y
    public static bool calendarEverOpend;  //���
    public static bool mirrorEverOpend; //��l
    public static bool dollEverOpend; //����
    public static bool electricalboxEverOpend; //�q�c
    public static bool tubEverOpend; //�D��
    public static bool doorEverOpend; //��
    public static bool cabinetEverOpend; //�p���d�l
    public static bool cupboardEverOpend; //�a�U���d�l
    public static bool ResEverOpend; //����
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
    }
}
