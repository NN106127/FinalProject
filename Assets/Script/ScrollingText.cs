using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    public Text textPrefab;
    public Transform displayArea;
    public float scrollSpeed = 20f;
    public float fadeSpeed = 1f;
    public float verticalSpacing = 30f; // 調整這個值以確保文字不重疊
    // Start is called before the first frame update
    void Start()
    {
        // 在這裡啟動向上滾動字幕的協程
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        string message = "Yourscrollingtexthere.";  // 要滾動的文本內容

        foreach (char c in message)
        {
            // 創建一個新的文字元素
            Text newText = Instantiate(textPrefab, displayArea);
            newText.text = c.ToString();

            // 設定每個文字的位置
            RectTransform rectTransform = newText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -verticalSpacing);

            // 更新下一個文字的垂直位置
            verticalSpacing += newText.preferredHeight;

            // 等待一小段時間再顯示下一個字符
            yield return new WaitForSeconds(0.1f);
        }

        // 滾動完成後的清理工作（例如銷毀物體、切換場景等）
        yield return new WaitForSeconds(2f); // 停留一段時間，可以根據需要調整
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        // 向上移動所有子物體（字元）
        foreach (Transform child in displayArea)
        {
            child.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);

            // 淡出效果
            Text text = child.GetComponent<Text>();
            Color color = text.color;
            color.a -= fadeSpeed * Time.deltaTime;
            text.color = color;
        }
    }
}
