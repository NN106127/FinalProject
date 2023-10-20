using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openitem2 : MonoBehaviour
{
    public GameObject item;
    public float delay = 2.0f; // ����ɶ��]�H�����^
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.activeSelf == true)
        {
            
            StartCoroutine(ShowImageAfterDelay());
        }
        else
        {
            item.SetActive(false);
        }
            // �Ұ� Coroutine �H������ܹϤ�
        StartCoroutine(ShowImageAfterDelay());
    }
    private System.Collections.IEnumerator ShowImageAfterDelay()
    {
        // ���ݫ��w������ɶ�
        yield return new WaitForSeconds(delay);

        // ��ܹϤ�
        item.SetActive(true);
    }
}
