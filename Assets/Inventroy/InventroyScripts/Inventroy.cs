using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventroy", menuName = "Inventroy/ New Inventroy")]
public class Inventroy : ScriptableObject
{
    public List<item> itemList = new List<item>();
}
