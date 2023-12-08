using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu2 : MonoBehaviour
{
    public AudioSource m_audio;
    public AudioSource backGroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(m_audio);
        backGroundMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScence(string scencename)
    {
        m_audio.Play();
        backGroundMusic.Stop();
        //SceneManager.LoadScene(0);
        SceneManager.LoadSceneAsync(scencename);
    }
}
