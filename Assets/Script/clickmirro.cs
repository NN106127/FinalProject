using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickmirro : MonoBehaviour
{
    public float moveSpeed = 1f;      // ����ʳt��
    public float scaleSpeed = 0.01f;  // �����j�t��

    private RectTransform mirrortransform;
    private Vector2 targetPosition;

    public GameObject mirrorbtn;

    //private Collider2D objectCollider;
    // Start is called before the first frame update
    void Start()
    {
        //objectCollider = GetComponent<Collider2D>();
        mirrorbtn.SetActive(false);
        mirrortransform = GetComponent<RectTransform>();
        targetPosition = new Vector2(Screen.width / -15, Screen.height / 15);
    }

    // Update is called once per frame
    void Update()
    {
        /*// �ˬd���a�O�_�I���F�ƹ�����
        if (Input.GetMouseButtonDown(0))
        {
            // �q��v���o�g�@���g�u���I����m
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // �ˬd�g�u�O�_�I��F�o�Ӫ��� Collider
            if (hit.collider != null && hit.collider == objectCollider)
            {
                OnObjectClicked();
            }
        }*/
    }
    public void OnObjectClicked()
    {
        mirrorbtn.SetActive(true);

        // ���ʹϤ��줤��
        mirrortransform.anchoredPosition = Vector2.MoveTowards(mirrortransform.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

        // �v����j�Ϥ�
        mirrortransform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;
    }
}
