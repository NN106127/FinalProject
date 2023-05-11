using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImage : MonoBehaviour
{
    //public GameObject image;
    public float showTime = 0.5f;
    public float hideTime = 2.0f;
    public SpriteRenderer image;
    //public float minDelay = 1f;
    //public float maxDelay = 5f;
    public float minX = -3f;
    public float maxX = -1f;
    public float minY = 1f;
    public float maxY = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowImage());
    }
    private IEnumerator ShowImage()
    {
        while (true)
        {
            // �]�w�Ϥ���m
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            transform.position = new Vector3(x, y, 0);

            /*// ��ܹϤ�
            image.enabled = true;

            // �����H���ɶ�
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // ���ùϤ�
            image.enabled = false;*/
            yield return new WaitForSeconds(5.0f); // ���� 5 ��
            image.enabled = true; // ��ܹϤ�
            yield return new WaitForSeconds(showTime); // ���� showTime ��
            image.enabled = false; // ���ùϤ�
            yield return new WaitForSeconds(hideTime); // ���� hideTime ��
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*IEnumerator Start()
    {
        while (true)
        {
            
        }
    }*/

}
