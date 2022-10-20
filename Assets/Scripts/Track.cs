using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public VideoPlayer video;
    public Text timetext;
    public VideoCont videocont;
    Slider tracking;
    bool slide = false;
    public List<QuestionArray> QArray;
    public int clipIndex,questionIndex = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        slide = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float frame = (float)tracking.value * (float)video.frameCount;
        video.frame = (long)frame;
        tracking.value = (float)video.frame / (float)video.frameCount;
        slide = false;
    }

    void Start()
    {
         tracking = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        timetext.text = ((int)(video.time/60)).ToString("D2")+":"+((int)(video.time%60)).ToString("D2");
        if (!slide)
        {
            tracking.value = (float)video.frame / (float)video.frameCount;
            Debug.Log((float)video.frame + " " + (float)video.frameCount);
            
        }
        for(int i = 0;i<QArray[clipIndex].playtime.Length-1;i++)
        {
            if(QArray[clipIndex].playtime[i]<=video.time && QArray[clipIndex].playtime[i+1] > video.time)
            {
                questionIndex = i;
            }
        }
        if ((float)video.frame == (float)video.frameCount - 1)
        {
            videocont.PauseBtnPressed();
            questionIndex = QArray[clipIndex].playtime.Length - 1;
            //video.frame = 0;
        }
    }

    public void NextBtnPressed()
    {
        questionIndex += 1;
        if(questionIndex >= QArray[clipIndex].playtime.Length)
        {
            questionIndex = QArray[clipIndex].playtime.Length -1;
            video.time = QArray[clipIndex].playtime[questionIndex];
            tracking.value = (float)video.frame / (float)video.frameCount;
        }
        else
        {
            video.time = QArray[clipIndex].playtime[questionIndex];
            tracking.value = (float)video.frame / (float)video.frameCount;
        }
    }
    public void PrevBtnPressed()
    {
        questionIndex -= 1;
        if (questionIndex < 0)
        {
            questionIndex = 0;
            video.time = QArray[clipIndex].playtime[questionIndex];
            tracking.value = (float)video.frame / (float)video.frameCount;
        }
        else
        {
            video.time = QArray[clipIndex].playtime[questionIndex];
            tracking.value = (float)video.frame / (float)video.frameCount;
            
        }
    }
}
[Serializable]
public class QuestionArray
{
    public float[] playtime;
}
