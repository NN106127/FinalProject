using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closebtn : MonoBehaviour
{
    public GameObject background;
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        background.SetActive(false);
        img.SetActive(false);
        GameObject playerObj = GameObject.Find("Player");
        Player playerScript = playerObj.GetComponent<Player>();
        playerScript.isMovementEnabled = true;
    }


}
