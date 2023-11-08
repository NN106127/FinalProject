using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //女鬼
    public SpriteRenderer spriteRenderer;
    public float Alpha = 1.0f;
    public float appearDelay = 5.0f; // 出现的延迟时间(這個先別動)
    public float fadeSpeed = 0.5f; // 閃爍速度調這裡(可調
    public float currentAlpha = 1.0f;
    public bool fadingOut = true;

    //追逐
    string status = "standby";    //設定狀態
    public float speed = 3.0f;           //追逐速度調這裡(可調
    public float accelerationRate = 0.1f; // 隨著時間加速度(可調
    private float currentSpeed;

    public Transform Player;
    public GameObject RestPlayer;

    public float detectionRange; // 在X轴上的检测范围(開始追逐範圍
    public float EncounterRange; // 進到範圍發出女鬼哀豪
    public float distanceToVisualize;
    public Transform RestPosition;

    public GameObject RestartUI;
    public GameObject Camera01;
    public GameObject Camera02;

    // Start is called before the first frame update
    void Start() 
    {
        currentSpeed = speed;
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // 设置Alpha值
        Color color = spriteRenderer.color;
        color.a = Alpha;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == "standby")
        {
            if (fadingOut == true)
            {
                // 减少Alpha值
                currentAlpha -= fadeSpeed * Time.deltaTime;
                if (currentAlpha <= 0.0f)
                {
                    currentAlpha = 0.0f;
                    fadingOut = false;
                }
            }
            else
            {
                // 增加Alpha值
                currentAlpha += fadeSpeed * Time.deltaTime;
                if (currentAlpha >= 1.0f)
                {
                    currentAlpha = 1.0f;
                    fadingOut = true;
                }
            }

            // 更新Sprite Renderer的颜色
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;
        }

        if (status == "found")
        {
            currentAlpha = 1;
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            currentSpeed += accelerationRate * Time.deltaTime;
            transform.Translate(direction * speed * Time.deltaTime);

        }

        if(status == "Rest")
        {
            transform.position = RestPosition.transform.position;
            status = "standby";
        }

        if(Input.GetKey(KeyCode.P))
        {
            currentAlpha = 1.0f;
            status = "found";
        }
    }

    void FixedUpdate()
    {
        // 在X轴上使用射线检测范围
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = Player.position;
        float distanceX = Mathf.Abs(playerPosition.x - enemyPosition.x);
        float distanceY = Mathf.Abs(playerPosition.y - enemyPosition.y);

        if (Input.GetKey(KeyCode.M))
        {
            Debug.Log("" + distanceY);
        }

        if (distanceX <= detectionRange && distanceY <= 0.78)
        {
            // 玩家在检测范围内，开始追踪
            status = "found";
        }
        else
        {
            // 玩家超出检测范围，停止追踪
            status = "Rest";
        }

        if(distanceX <= EncounterRange)
        {
            //音效寫這裡
            Debug.Log("進到範圍了");
        }
    }

    private void OnDrawGizmos()//看範圍用的可以自己打開
    {
        Gizmos.color = Color.red; // 设置Gizmos的颜色

        // 在指定位置绘制一个球形Gizmo，用于表示距离
        Gizmos.DrawWireSphere(transform.position, distanceToVisualize);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //被碰到寫在這裡
            RestartUI.SetActive(true);
            speed = 0;
        }
    }

    public void OnRestartClick()
    {
        Player.transform.position = RestPlayer.transform.position;
        RestartUI.SetActive(false);
        Camera01.SetActive(true);
        Camera02.SetActive(false);
    }    
}