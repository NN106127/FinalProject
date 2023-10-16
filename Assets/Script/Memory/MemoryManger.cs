using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryManger : MonoBehaviour
{
    public MemoryConnect memoryConnect1;
    public MemoryConnect memoryConnect2;
    public MemoryConnect memoryConnect3;
    public MemoryConnect memoryConnect4;
    public MemoryConnect memoryConnect5;
    public Image[] Memory;
    public List<string> strings = new List<string>();
    public string Ans;
    public int t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CheckMemory();
            MemoryAnime();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetMemory();
        }

    }

    void CheckMemory()
    {
        if (memoryConnect1.i == "" || memoryConnect2.i == "" || memoryConnect3.i == "" || memoryConnect4.i == "" || memoryConnect5.i == "")
        {
            Debug.Log("請放滿記憶碎片");
        }
        else if (t == 0)
        {
            strings.Add(memoryConnect1.i);
            strings.Add(memoryConnect2.i);
            strings.Add(memoryConnect3.i);
            strings.Add(memoryConnect4.i);
            strings.Add(memoryConnect5.i);
            //Debug.Log("" + memoryConnect1.i + memoryConnect2.i + memoryConnect3.i + memoryConnect4.i + memoryConnect5.i);
            Ans = memoryConnect1.i;
            t = 1;
        }
    }

    void ResetMemory()
    {
        strings.Remove(memoryConnect1.i);
        strings.Remove(memoryConnect2.i);
        strings.Remove(memoryConnect3.i);
        strings.Remove(memoryConnect4.i);
        strings.Remove(memoryConnect5.i);
        t = 0;
    }

    void MemoryAnime()
    {
        if(Ans == "1")
        {
            Debug.Log("A");
        }

        if (Ans == "2")
        {
            Debug.Log("B");
        }

        if (Ans == "3")
        {
            Debug.Log("C");
        }

        if (Ans == "4")
        {
            Debug.Log("D");
        }

        if (Ans == "5")
        {
            Debug.Log("C");
        }
    }
}
