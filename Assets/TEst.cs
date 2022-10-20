using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TEst : MonoBehaviour
{
    public VideoPlayer videoplayer;
    public VideoClip videoclip;

    public void click()
    {
        videoplayer.clip = videoclip;
        videoplayer.Play();
    }
}
