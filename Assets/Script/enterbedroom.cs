using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class enterbedroom : MonoBehaviour
{
    public Transform bedroomTransform;
    public Transform secondFloorTransform; // 二樓的位置
    public Transform playerTransform; // 人物的Transform組件
    public float teleportRange = 1.0f; // 傳送範圍
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
                // 檢查玩家是否在傳送範圍內
                if (Vector2.Distance(playerTransform.position, bedroomTransform.position) <= teleportRange)
                {
                    // 移動人物到一樓開啟一樓攝影機
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
                // 檢查玩家是否在傳送範圍內
                if (Vector2.Distance(playerTransform.position, secondFloorTransform.position) <= teleportRange)
                {
                    // 移動人物到二樓開啟二樓攝影機
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
