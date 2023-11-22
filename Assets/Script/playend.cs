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


    private void Start()
    {
        // 禁用所有 VideoPlayer
        videoPlayer1.gameObject.SetActive(false);
        videoPlayer2.gameObject.SetActive(false);
        videoPlayer3.gameObject.SetActive(false);
        videoPlayer4.gameObject.SetActive(false);
    }
    
    // 接收名为 "PlayVideo" 的消息
    void PlayVideo(string videoIdentifier)
    {
        
        // 根据收到的消息参数决定要播放哪个视频
        switch (videoIdentifier)
        {
            case "Video1":
                // 启用并播放 videoPlayer1
                videoPlayer1.gameObject.SetActive(true);
                videoPlayer1.Play();
                break;
            case "Video2":
                // 启用并播放 videoPlayer2
                videoPlayer2.gameObject.SetActive(true);
                videoPlayer2.Play();
                break;
            case "Video3":
                // 启用并播放 videoPlayer3
                videoPlayer3.gameObject.SetActive(true);
                videoPlayer3.Play();
                break;
            case "Video4":
                // 启用并播放 videoPlayer4
                videoPlayer4.gameObject.SetActive(true);
                videoPlayer4.Play();
                break;
            default:
                break;

        }
    }
}
