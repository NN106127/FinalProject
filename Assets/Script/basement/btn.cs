using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn : MonoBehaviour
{
    public List<Image> Images = new List<Image>();
    public List<ChangeSource> Index = new List<ChangeSource>();
    int currentindex;
    bool Active;
    bool Clear;
    //public Text text;
    public Image AnsImage;
    public Sprite AnsCorrect;
    public Sprite Rest;
    public bool CanClick = true;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Image image in Images)
        {
            Image imageComponent = image.GetComponent<Image>();
        }

        foreach (ChangeSource index in Index)
        {
            int currentindex = index.currentIndex;
            Active = index.isActive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanClick == true)
        {
            CheckImage();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void CheckImage()
    {
        foreach (ChangeSource index in Index)
        {
            int currentindex = index.currentIndex;
            if (Index[0].currentIndex == 1)
            {
                //text.text = "不對喔";
                if (Index[1].currentIndex == 1)
                {
                    //text.text = "不對喔";
                    if (Index[2].currentIndex == 1)
                    {
                        //text.text = "不對喔";
                        if (Index[3].currentIndex == 1)
                        {
                            //text.text = "不對喔";
                            if (Index[4].currentIndex == 1)
                            {
                               //text.text = "不對喔";
                                if (Index[5].currentIndex == 1)
                                {
                                    //text.text = "不對喔";
                                    if (Index[6].currentIndex == 1)
                                    {
                                        //text.text = "不對喔";
                                        if (Index[7].currentIndex == 1)
                                        {
                                            //text.text = "不對喔";
                                            if (Index[8].currentIndex == 1)
                                            {
                                                if (Index[9].currentIndex == 1)
                                                {
                                                    //text.text = "不對喔";
                                                    if (Index[10].currentIndex == 1)
                                                    {
                                                        //text.text = "不對喔";
                                                        if (Index[11].currentIndex == 1)
                                                        {
                                                           //text.text = "你好棒";
                                                            Debug.Log("Clear");
                                                            AnsImage.sprite = AnsCorrect;
                                                            CanClick = false;
                                                            //全對通關
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void Index0Change()
    {
        Index[1].isActive = !Index[1].isActive;
        Index[4].isActive = !Index[4].isActive;
    }

    public void Index1Change()
    {
        Index[0].isActive = !Index[0].isActive;
        Index[2].isActive = !Index[2].isActive;
        Index[5].isActive = !Index[5].isActive;
    }

    public void Index2Change()
    {
        Index[1].isActive = !Index[1].isActive;
        Index[3].isActive = !Index[3].isActive;
        Index[6].isActive = !Index[6].isActive;
    }

    public void Index3Change()
    {
        Index[2].isActive = !Index[2].isActive;
        Index[7].isActive = !Index[7].isActive;
    }

    public void Index4Change()
    {
        Index[0].isActive = !Index[0].isActive;
        Index[5].isActive = !Index[5].isActive;
        Index[8].isActive = !Index[8].isActive;
    }

    public void Index5Change()
    {
        Index[1].isActive = !Index[1].isActive;
        Index[4].isActive = !Index[4].isActive;
        Index[6].isActive = !Index[6].isActive;
        Index[9].isActive = !Index[9].isActive;
    }

    public void Index6Change()
    {
        Index[2].isActive = !Index[2].isActive;
        Index[5].isActive = !Index[5].isActive;
        Index[7].isActive = !Index[7].isActive;
        Index[10].isActive = !Index[10].isActive;
    }

    public void Index7Change()
    {
        Index[3].isActive = !Index[3].isActive;
        Index[6].isActive = !Index[6].isActive;
        Index[11].isActive = !Index[11].isActive;
    }

    public void Index8Change()
    {
        Index[4].isActive = !Index[4].isActive;
        Index[9].isActive = !Index[9].isActive;
    }

    public void Index9Change()
    {
        Index[5].isActive = !Index[5].isActive;
        Index[8].isActive = !Index[8].isActive;
        Index[10].isActive = !Index[10].isActive;
    }

    public void Index10Change()
    {
        Index[6].isActive = !Index[6].isActive;
        Index[9].isActive = !Index[9].isActive;
        Index[11].isActive = !Index[11].isActive;
    }

    public void Index11Change()
    {
        Index[7].isActive = !Index[7].isActive;
        Index[10].isActive = !Index[10].isActive;
    }

    public void Restart()
    {
        Index[0].isActive = false;
        Index[1].isActive = false;
        Index[2].isActive = false;
        Index[3].isActive = false;
        Index[4].isActive = false;
        Index[5].isActive = false;
        Index[6].isActive = false;
        Index[7].isActive = false;
        Index[8].isActive = false;
        Index[9].isActive = false;
        Index[10].isActive = false;
        Index[11].isActive = false;
        AnsImage.sprite = Rest;
        //text.text = "";
    }
}
