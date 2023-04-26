using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterbedroom : MonoBehaviour
{
    public Transform bedroomTransform;
    public Transform secondFloorTransform; // �G�Ӫ���m
    public Transform playerTransform; // �H����Transform�ե�
    public float teleportRange = 1.0f; // �ǰe�d��
    public GameObject cam2;
    public GameObject cam3;
    public GameObject enter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �ˬd���a�O�_�b�ǰe�d��
            if (Vector2.Distance(playerTransform.position, bedroomTransform.position) <= teleportRange)
            {
                // ���ʤH����@�Ӷ}�Ҥ@����v��
                playerTransform.position = bedroomTransform.position;
                
                cam2.SetActive(false);
                cam3.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // �ˬd���a�O�_�b�ǰe�d��
            if (Vector2.Distance(playerTransform.position, secondFloorTransform.position) <= teleportRange)
            {
                // ���ʤH����G�Ӷ}�ҤG����v��
                playerTransform.position = secondFloorTransform.position;

                cam3.SetActive(false);
                cam2.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            enter.SetActive(true);

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            enter.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            enter.SetActive(false);

        }

    }
}
