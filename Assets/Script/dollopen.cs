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

    public float delay = 2.0f; // 延遲時間（以秒為單位）

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
        // 檢查玩家是否點擊了滑鼠左鍵
        if (Input.GetMouseButtonDown(0))
        {
            // 從攝影機發射一條射線到點擊位置
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // 檢查射線是否碰到了這個物件的 Collider
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
        // 啟動 Coroutine 以延遲顯示圖片
        StartCoroutine(ShowImageAfterDelay());

    }
    private System.Collections.IEnumerator ShowImageAfterDelay()
    {
        // 等待指定的延遲時間
        yield return new WaitForSeconds(delay);

        // 顯示圖片
        dollain1.SetActive(false);
        dollain2.SetActive(true);
        memory.SetActive(true);
        dollsound.Stop();
        memorysound.Play();
    }
}
