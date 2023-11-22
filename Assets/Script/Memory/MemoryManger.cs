using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public string nextSceneName = "end";
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
        memoryConnect1.i = "";
        memoryConnect2.i = "";
        memoryConnect3.i = "";
        memoryConnect4.i = "";
        memoryConnect5.i = "";
        Ans = "";
        t = 0;
    }

    void MemoryAnime()
    {
        
        switch (Ans)
        {
            case "1":
                Debug.Log("A");
                // 发送消息到名为 "PlayVideo" 的函数，参数可以是影片的标识符或其他信息
                SendMessage("PlayVideo", "Video1");
                break;
            case "2":
                Debug.Log("B");
                // 发送消息到名为 "PlayVideo" 的函数，参数可以是影片的标识符或其他信息
                SendMessage("PlayVideo", "Video2");
                break;
            case "3":
                Debug.Log("C");
                // 发送消息到名为 "PlayVideo" 的函数，参数可以是影片的标识符或其他信息
                SendMessage("PlayVideo", "Video3");
                break;
            case "4":
                Debug.Log("D");
                // 发送消息到名为 "PlayVideo" 的函数，参数可以是影片的标识符或其他信息
                SendMessage("PlayVideo", "Video4");
                break;
            case "5":
                Debug.Log("C");
                // 发送消息到名为 "PlayVideo" 的函数，参数可以是影片的标识符或其他信息
                SendMessage("PlayVideo", "Video5");
                break;
            default:
                break;
        }
        if (Ans == "1")
        {
            Debug.Log("A");
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "2")
        {
            Debug.Log("B");
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "3")
        {
            Debug.Log("C");
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "4")
        {
            Debug.Log("D");
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "5")
        {
            Debug.Log("C");
            SceneManager.LoadScene(nextSceneName);
        }
        
    }
}
