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
    public float verticalSpacing = 30f; // �վ�o�ӭȥH�T�O��r�����|
    // Start is called before the first frame update
    void Start()
    {
        // �b�o�̱ҰʦV�W�u�ʦr������{
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        string message = "Yourscrollingtexthere.";  // �n�u�ʪ��奻���e

        foreach (char c in message)
        {
            // �Ыؤ@�ӷs����r����
            Text newText = Instantiate(textPrefab, displayArea);
            newText.text = c.ToString();

            // �]�w�C�Ӥ�r����m
            RectTransform rectTransform = newText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -verticalSpacing);

            // ��s�U�@�Ӥ�r��������m
            verticalSpacing += newText.preferredHeight;

            // ���ݤ@�p�q�ɶ��A��ܤU�@�Ӧr��
            yield return new WaitForSeconds(0.1f);
        }

        // �u�ʧ����᪺�M�z�u�@�]�Ҧp�P������B�����������^
        yield return new WaitForSeconds(2f); // ���d�@�q�ɶ��A�i�H�ھڻݭn�վ�
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        // �V�W���ʩҦ��l����]�r���^
        foreach (Transform child in displayArea)
        {
            child.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);

            // �H�X�ĪG
            Text text = child.GetComponent<Text>();
            Color color = text.color;
            color.a -= fadeSpeed * Time.deltaTime;
            text.color = color;
        }
    }
}
