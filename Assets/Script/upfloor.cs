using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upfloor : MonoBehaviour
{
    public Transform playerTransform; // �H����Transform�ե�
    //public Transform cameraTransform; // ��v����Transform�ե�
    public Transform firstFloorTransform; // �@�Ӫ���m
    public Transform secondFloorTransform; // �G�Ӫ���m
    public float teleportRange = 1.0f; // �ǰe�d��

    public GameObject cam1;
    public GameObject cam2;
    
    public GameObject up;
    public GameObject donwn;
    bool CanW;
    bool CanS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanW == true)
        {
            // �˴����a�O�_���U"W"��
            if (Input.GetKeyDown(KeyCode.W))
            {
                // �ˬd���a�O�_�b�ǰe�d��
                if (Vector2.Distance(playerTransform.position, secondFloorTransform.position) <= teleportRange)
                {
                    // ���ʤH����G�Ӷ}�_�G����v��
                    playerTransform.position = secondFloorTransform.position;
                    cam1.SetActive(false);
                    cam2.SetActive(true);
                }
            }
            
        }
        if (CanS == true)
        {
            // �˴����a�O�_���U"S"��
            if (Input.GetKeyDown(KeyCode.S))
            {
                // �ˬd���a�O�_�b�ǰe�d��
                if (Vector2.Distance(playerTransform.position, firstFloorTransform.position) <= teleportRange)
                {
                    // ���ʤH����@�Ӷ}�Ҥ@����v��
                    playerTransform.position = firstFloorTransform.position;
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                }
            }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            CanS = true;
            CanW = true;
            up.SetActive(true);
            donwn.SetActive(true);
            

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanS = true;
            CanW = true;
            up.SetActive(true);
            donwn.SetActive(true);
            
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanS = false;
            CanW = false;
            up.SetActive(false);
            donwn.SetActive(false);
            

        }

    }
}
