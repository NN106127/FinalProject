using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class playend : MonoBehaviour
{
    public GameObject videoPlayer1;
    public GameObject videoPlayer2;
    public GameObject videoPlayer3;
    public GameObject videoPlayer4;
    public GameObject videoPlayer5;
    public GameObject imageToShow; // 要显示的图片
    private VideoPlayer currentVideoPlayer;

    private void Start()
    {
        imageToShow.SetActive(false);
        int videoToPlay = PlayerPrefs.GetInt("VideoToPlay", 1);
        // 禁用所有 VideoPlayer
        videoPlayer1.SetActive(false);
        videoPlayer2.SetActive(false);
        videoPlayer3.SetActive(false);
        videoPlayer4.SetActive(false);
        videoPlayer5.SetActive(false);

        // 根據 videoToPlay 的值執行不同的影片撥放操作
        PlayVideo(videoToPlay);
    }
    void PlayVideo(int videoIndex)
    {
        if (currentVideoPlayer != null)
        {
            currentVideoPlayer.Stop();
            currentVideoPlayer.loopPointReached -= OnVideoEndReached;
        }
        // 根據 videoIndex 撥放相應的影片
        // 這裡是一個示例，您需要根據實際需求替換成相應的撥放影片的邏輯
        switch (videoIndex)
        {
            case 1:
                Debug.Log("Play Video 1");
                //全活
                currentVideoPlayer = videoPlayer1.GetComponent<VideoPlayer>();
                videoPlayer1.gameObject.SetActive(true);


                break;
            case 2:
                Debug.Log("Play Video 2");
                // 傑諾
                currentVideoPlayer = videoPlayer2.GetComponent<VideoPlayer>();
                videoPlayer2.gameObject.SetActive(true);

                break;
            case 3:
                Debug.Log("Play Video 3");
                // 宇森
                currentVideoPlayer = videoPlayer3.GetComponent<VideoPlayer>();
                videoPlayer3.gameObject.SetActive(true);

                break;
            case 4:
                Debug.Log("Play Video 4");
                // 陸浩
                currentVideoPlayer = videoPlayer4.GetComponent<VideoPlayer>();
                videoPlayer4.gameObject.SetActive(true);

                break;
            case 5:
                Debug.Log("Play Video 5");
                // 全死
                currentVideoPlayer = videoPlayer5.GetComponent<VideoPlayer>();
                videoPlayer5.gameObject.SetActive(true);

                break;
            default:
                Debug.LogError("Invalid video index");
                break;
        }
        if (currentVideoPlayer != null)
        {
            currentVideoPlayer.loopPointReached += OnVideoEndReached;
        }

    }
    void OnVideoEndReached(VideoPlayer vp)
    {
        // 影片播放結束時觸發這個方法
        imageToShow.SetActive(true);

        Debug.Log("Video End Reached");
    }

}