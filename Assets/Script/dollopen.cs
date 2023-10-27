using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollopen : MonoBehaviour
{
    private Collider2D objectCollider;

    public GameObject doll;
    public GameObject dollain1;
    public GameObject dollain2;
    public GameObject memory;

    public float delay = 2.0f; // ����ɶ��]�H�����^

    public AudioSource dollsound;
    public AudioSource memorysound;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ˬd���a�O�_�I���F�ƹ�����
        if (Input.GetMouseButtonDown(0))
        {
            // �q��v���o�g�@���g�u���I����m
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // �ˬd�g�u�O�_�I��F�o�Ӫ��� Collider
            if (hit.collider != null && hit.collider == objectCollider)
            {
                OnObjectClicked();
            }
        }
        if (!OpenState.dollEverOpend)
        {
            doll.SetActive(false);
        }
        else
        {
            doll.SetActive(true);
        }
    }
    public void OnObjectClicked()
    {
        dollain1.SetActive(true);
        dollsound.Play();
        // �Ұ� Coroutine �H������ܹϤ�
        StartCoroutine(ShowImageAfterDelay());

    }
    private System.Collections.IEnumerator ShowImageAfterDelay()
    {
        // ���ݫ��w������ɶ�
        yield return new WaitForSeconds(delay);

        // ��ܹϤ�
        dollain1.SetActive(false);
        dollain2.SetActive(true);
        memory.SetActive(true);
        dollsound.Stop();
        memorysound.Play();
    }
}
