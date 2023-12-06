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

    //文字
    public Text text;
    public float fadeSpeed = 0.5f;
    Color newColor;
    public bool Show;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        Color newColor = text.color;
        text.color = newColor;
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

        if (Show == true)
        {
            StartCoroutine(FadeTextRoutine());
        }
    }

    IEnumerator FadeTextRoutine()
    {
        while (text.color.a > 0.0f)
        {
            // 降低透明度
            newColor = text.color;
            newColor.a -= fadeSpeed * Time.deltaTime;
            text.color = newColor;

            // 等待一帧
            yield return null;
        }
    }

    void CheckMemory()
    {
        if (memoryConnect1.i == "" || memoryConnect2.i == "" || memoryConnect3.i == "" || memoryConnect4.i == "" || memoryConnect5.i == "")
        {
            text.text = "※請放滿記憶碎片";
            newColor.a = 1.0f;
            text.color = newColor;
            text.color = Color.white;
            Show = true;
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
        text.text = "已重置記憶碎片順序";
        newColor.a = 1.0f;
        text.color = newColor;
        text.color = Color.white;
        Show = true;
    }

    void MemoryAnime()
    {
        if (Ans == "1")
        {
            Debug.Log("A");
            PlayerPrefs.SetInt("VideoToPlay", 1);
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "2")
        {
            Debug.Log("B");
            PlayerPrefs.SetInt("VideoToPlay", 2);
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "3")
        {
            Debug.Log("C");
            PlayerPrefs.SetInt("VideoToPlay", 3);
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "4")
        {
            Debug.Log("D");
            PlayerPrefs.SetInt("VideoToPlay", 4);
            SceneManager.LoadScene(nextSceneName);
        }

        if (Ans == "5")
        {
            Debug.Log("E");
            PlayerPrefs.SetInt("VideoToPlay", 5);
            SceneManager.LoadScene(nextSceneName);
        }
        
    }
    public void Clickedright()
    {
        CheckMemory();
        MemoryAnime();
    }
    public void Clickedreset()
    {
        ResetMemory();
    }
}
