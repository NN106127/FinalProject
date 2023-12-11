using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    [Header("Text物件")]
    public Text textPrefab;
    [Header("生成區域")]
    public Transform displayArea;
    [Header("漸出速度")]
    public float fadeSpeed = 5f;
    [Header("垂直生成間距")]
    public float verticalSpacing = 0f; // 調整這個值以確保文字不重疊
    [Header("Text向上捲動速度")]
    public float scrollSpeed = 20f;
    [Header("Text生成速度間格")]
    public float SpawnSpeed = 1f;
    [Header("文本內容")]
    public string[] dialogLines; // 對話內容
    [Header("文本打字速度")]
    public float typeSpeed; // 打字速度

    public GameObject team;
    public GameObject thx;
    public AudioSource backGroundMusic;
    // Start is called before the first frame update
    private void OnEnable()
    {
        backGroundMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>();
        team.SetActive(false);
        thx.SetActive(false);
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {

        foreach (string s in dialogLines)
        {
            // 創建一個新的文字元素
            Text newText = Instantiate(textPrefab, displayArea);
            newText.GetComponent<TextFadeOut>().fadeSpeed = fadeSpeed;

            // 設定每個文字的位置
            RectTransform rectTransform = newText.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -verticalSpacing);

            // 更新下一個文字的垂直位置
            verticalSpacing += newText.preferredHeight;

            foreach (char c in s.ToCharArray())
            {

                newText.text += c; // 一個一個字元輸出文字
                yield return new WaitForSeconds(typeSpeed); // 等待typeSpeed秒再輸出下一個字元

            }

            // 等待一小段時間再顯示下一個字符
            yield return new WaitForSeconds(SpawnSpeed);
        }

        // 滾動完成後的清理工作（例如銷毀物體、切換場景等）
        yield return new WaitForSeconds(14f); // 停留一段時間，可以根據需要調整
        team.SetActive(true);
        yield return new WaitForSeconds(12f);
        thx.SetActive(true);
        yield return new WaitForSeconds(11f);
        backGroundMusic.Stop();
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        // 向上移動所有子物體（字元）
        foreach (Transform child in displayArea)
        {
            child.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);
        }
    }
}
