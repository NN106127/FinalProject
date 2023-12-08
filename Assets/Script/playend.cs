using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class playend : MonoBehaviour
{
    public VideoPlayer videoPlayer1; 
    public VideoPlayer videoPlayer2;
    public VideoPlayer videoPlayer3;
    public VideoPlayer videoPlayer4;
    public VideoPlayer videoPlayer5;


    private void Start()
    {
        int videoToPlay = PlayerPrefs.GetInt("VideoToPlay", 1);
        // 禁用所有 VideoPlayer
        videoPlayer1.gameObject.SetActive(false);
        videoPlayer2.gameObject.SetActive(false);
        videoPlayer3.gameObject.SetActive(false);
        videoPlayer4.gameObject.SetActive(false);
        videoPlayer5.gameObject.SetActive(false);
        // 根據 videoToPlay 的值執行不同的影片撥放操作
        PlayVideo(videoToPlay);
    }
    void PlayVideo(int videoIndex)
    {
        // 根據 videoIndex 撥放相應的影片
        // 這裡是一個示例，您需要根據實際需求替換成相應的撥放影片的邏輯
        switch (videoIndex)
        {
            case 1:
                Debug.Log("Play Video 1");
                //全活
                videoPlayer1.gameObject.SetActive(true);
                break;
            case 2:
                Debug.Log("Play Video 2");
                // 傑諾
                videoPlayer2.gameObject.SetActive(true);
                break;
            case 3:
                Debug.Log("Play Video 3");
                // 宇森
                videoPlayer3.gameObject.SetActive(true);
                break;
            case 4:
                Debug.Log("Play Video 4");
                // 陸浩
                videoPlayer4.gameObject.SetActive(true);
                break;
            case 5:
                Debug.Log("Play Video 5");
                // 全死
                videoPlayer5.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid video index");
                break;
        }
    }
    }
