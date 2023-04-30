using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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

    public float speed = 0.1f;
    private float targetIntensity = 0f;

    public Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        // ���oPost Processing Volume
        var volume = GetComponent<PostProcessVolume>();

        // ���oVignette�ĪG
        if (volume.profile.TryGetSettings(out vignette))
        {
            Debug.Log(1);
            // ��l��Vignette intensity
            vignette.intensity.value = 0f;
        }
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

                    targetIntensity = 1f;
                    // ����eintensity�ȩ��ؼ�intensity�Ƚw�C����
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetIntensity, Time.deltaTime * speed);

                    // �p�G��eintensity�Ȥw�g����ؼ�intensity�ȡA�h�N�ؼ�intensity�ȳ]�^0
                    if (Mathf.Abs(vignette.intensity.value - targetIntensity) < 0.01f)
                    {
                        targetIntensity = 0f;
                    }
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

                    targetIntensity = 1f;
                    // ����eintensity�ȩ��ؼ�intensity�Ƚw�C����
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetIntensity, Time.deltaTime * speed);

                    // �p�G��eintensity�Ȥw�g����ؼ�intensity�ȡA�h�N�ؼ�intensity�ȳ]�^0
                    if (Mathf.Abs(vignette.intensity.value - targetIntensity) < 0.01f)
                    {
                        targetIntensity = 0f;
                    }
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
