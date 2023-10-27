using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollopen : MonoBehaviour
{
    private Collider2D objectCollider;
    public GameObject doll;
    public GameObject dollain;
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
        dollain.SetActive(true);

    }
}
