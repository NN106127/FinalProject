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
    public static bool calendarEverOpend;      //���
    public static void Initial()
    {
        wardrobeEverOpened = false;
        aquariumEverOpened = false;
        fridgeEverOpened = false;
        ovenEverOpened = false;
        tipsEverOpend = false;
        calendarEverOpend = false;
    }
}
