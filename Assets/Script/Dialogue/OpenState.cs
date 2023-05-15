using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : MonoBehaviour
{
    public static bool wardrobeEverOpened; //¦çÂd
    public static bool aquariumEverOpened; //¤ô±Ú½c 
    public static bool fridgeEverOpened;   //¦B½c 
    public static bool ovenEverOpened;     //¯N½c
    public static bool tipsEverOpend;      //¶}ÀY
    public static bool calendarEverOpend;      //¤ë¾ä
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
