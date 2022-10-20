using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCont : MonoBehaviour
{
    public GameObject[] PlayBtn;
    public GameObject[] PauseBtn;
    public string[] VideoURL;
    public GameObject UIcanvas;
    public GameObject Videocanvas;
    public GameObject VideoExists;
    public GameObject noVideoCanvas;

    public Track slider;
    VideoPlayer VP;
    VideoCont VC;

    [SerializeField]
    string videoDir;

    private void Awake()
    {
        videoDir = Application.persistentDataPath + VideoURL[0];
        if (System.IO.File.Exists(videoDir))
        {
            UIcanvas.SetActive(true);
            noVideoCanvas.SetActive(false);
        }
        else
        {
            UIcanvas.SetActive(false);
            noVideoCanvas.SetActive(true);
        }
    }

    private void Start()
    {
        VP = GetComponent<VideoPlayer>();
        VC = GetComponent<VideoCont>();
    }

    private void Update()
    {
        if(VP.isPlaying)
        {
            PlayBtnPressed();
        }
        else
        {
            PauseBtnPressed();
        }
    }

    public void PlayBtnPressed()
    {
        foreach (GameObject g in PlayBtn)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in PauseBtn)
        {
            g.SetActive(true);
        }
        
    }

    public void PauseBtnPressed()
    {
        foreach (GameObject g in PlayBtn)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in PauseBtn)
        {
            g.SetActive(false);
        }
    }
    
    public void VideoPlay(int index)
    {
        VP.url = Application.persistentDataPath + VideoURL[index];
        if (System.IO.File.Exists(VP.url))
        { 
            UIcanvas.SetActive(false);
            Videocanvas.SetActive(true);
            slider.clipIndex = index;
            VP.frame = 0;
            VP.Play();
            VC.PlayBtnPressed();
        }
        else
        {
            UIcanvas.SetActive(false);
            VideoExists.SetActive(true);
        }
    }
    
    public void HomeBtnPressed()
    {
        VP.Pause();
        UIcanvas.SetActive(true);
        Videocanvas.SetActive(false);
    }
}

