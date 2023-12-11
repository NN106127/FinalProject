using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    [Header("Text����")]
    public Text textPrefab;
    [Header("�ͦ��ϰ�")]
    public Transform displayArea;
    [Header("���X�t��")]
    public float fadeSpeed = 5f;
    [Header("�����ͦ����Z")]
    public float verticalSpacing = 0f; // �վ�o�ӭȥH�T�O��r�����|
    [Header("Text�V�W���ʳt��")]
    public float scrollSpeed = 20f;
    [Header("Text�ͦ��t�׶���")]
    public float SpawnSpeed = 1f;
    [Header("�奻���e")]
    public string[] dialogLines; // ��ܤ��e
    [Header("�奻���r�t��")]
    public float typeSpeed; // ���r�t��

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
            // �Ыؤ@�ӷs����r����
            Text newText = Instantiate(textPrefab, displayArea);
            newText.GetComponent<TextFadeOut>().fadeSpeed = fadeSpeed;

            // �]�w�C�Ӥ�r����m
            RectTransform rectTransform = newText.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -verticalSpacing);

            // ��s�U�@�Ӥ�r��������m
            verticalSpacing += newText.preferredHeight;

            foreach (char c in s.ToCharArray())
            {

                newText.text += c; // �@�Ӥ@�Ӧr����X��r
                yield return new WaitForSeconds(typeSpeed); // ����typeSpeed��A��X�U�@�Ӧr��

            }

            // ���ݤ@�p�q�ɶ��A��ܤU�@�Ӧr��
            yield return new WaitForSeconds(SpawnSpeed);
        }

        // �u�ʧ����᪺�M�z�u�@�]�Ҧp�P������B�����������^
        yield return new WaitForSeconds(14f); // ���d�@�q�ɶ��A�i�H�ھڻݭn�վ�
        team.SetActive(true);
        yield return new WaitForSeconds(12f);
        thx.SetActive(true);
        yield return new WaitForSeconds(11f);
        backGroundMusic.Stop();
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        // �V�W���ʩҦ��l����]�r���^
        foreach (Transform child in displayArea)
        {
            child.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);
        }
    }
}
