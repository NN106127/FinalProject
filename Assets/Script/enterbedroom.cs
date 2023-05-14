using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class enterbedroom : MonoBehaviour
{
    public Transform bedroomTransform;
    public Transform secondFloorTransform; // �G�Ӫ���m
    public Transform playerTransform; // �H����Transform�ե�
    public float teleportRange = 1.0f; // �ǰe�d��
    public GameObject cam2;
    public GameObject cam3;
    public GameObject enter;
    bool CanE;
    bool CanQ;

    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private Coroutine vignetteCoroutine;
    public AudioSource door;
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanE == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                door.Play();
                // �ˬd���a�O�_�b�ǰe�d��
                if (Vector2.Distance(playerTransform.position, bedroomTransform.position) <= teleportRange)
                {
                    // ���ʤH����@�Ӷ}�Ҥ@����v��
                    playerTransform.position = bedroomTransform.position;

                    cam2.SetActive(false);
                    cam3.SetActive(true);
                }
                if (vignetteCoroutine != null)
                {
                    StopCoroutine(vignetteCoroutine);
                }

                vignetteCoroutine = StartCoroutine(ChangeVignetteIntensity());
            }
            

        }
        if (CanQ == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                door.Play();
                // �ˬd���a�O�_�b�ǰe�d��
                if (Vector2.Distance(playerTransform.position, secondFloorTransform.position) <= teleportRange)
                {
                    // ���ʤH����G�Ӷ}�ҤG����v��
                    playerTransform.position = secondFloorTransform.position;

                    cam3.SetActive(false);
                    cam2.SetActive(true);
                }
                if (vignetteCoroutine != null)
                {
                    StopCoroutine(vignetteCoroutine);
                }

                vignetteCoroutine = StartCoroutine(ChangeVignetteIntensity());
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            CanE = true;
            CanQ = true;
            enter.SetActive(true);

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanE = true;
            CanQ = true;
            enter.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanE = false;
            CanQ = false;
            enter.SetActive(false);

        }

    }
    private IEnumerator ChangeVignetteIntensity()
    {
        float time = 1f;
        float duration = 1f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;
            float intensity = Mathf.Lerp(0f, 1f, t);

            vignette.intensity.value = intensity;

            yield return null;
        }

        time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;
            float intensity = Mathf.Lerp(1f, 0f, t);

            vignette.intensity.value = intensity;

            yield return null;
        }

        vignette.intensity.value = 0f;
    }
}
