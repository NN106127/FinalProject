using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escui : MonoBehaviour
{
    [SerializeField] Transform UIPanel;
    //public GameObject image;
    public Slider volumeSlider;
    public AudioSource backGroundMusic;

    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
        backGroundMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       backGroundMusic.volume = volumeSlider.value;
        /*if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Pause();
            Debug.Log("Pause");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            unPause();
            Debug.Log("UnPause");
        }*/
    }

    public void OnClickMusic()
    {
        //image.SetActive(true);
        if (!isPause)
        {
            Pause();
            Debug.Log("Pause");
        }
        else if (isPause)
        {
            unPause();
            Debug.Log("UnPause");
        }
    }
    void Pause()
    {
        isPause = true;
        UIPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void unPause()
    {
        isPause = false;
        UIPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
