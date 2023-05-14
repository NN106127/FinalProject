using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmusic : MonoBehaviour
{
    public AudioSource m_audiobmusic;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(m_audiobmusic);

        m_audiobmusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
