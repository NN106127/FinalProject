using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickmirro : MonoBehaviour
{
    public float moveSpeed = 1f;      // 控制移動速度
    public float scaleSpeed = 0.01f;  // 控制放大速度

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
        /*// 檢查玩家是否點擊了滑鼠左鍵
        if (Input.GetMouseButtonDown(0))
        {
            // 從攝影機發射一條射線到點擊位置
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // 檢查射線是否碰到了這個物件的 Collider
            if (hit.collider != null && hit.collider == objectCollider)
            {
                OnObjectClicked();
            }
        }*/
    }
    public void OnObjectClicked()
    {
        mirrorbtn.SetActive(true);

        // 移動圖片到中心
        mirrortransform.anchoredPosition = Vector2.MoveTowards(mirrortransform.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

        // 逐漸放大圖片
        mirrortransform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;
    }
}
