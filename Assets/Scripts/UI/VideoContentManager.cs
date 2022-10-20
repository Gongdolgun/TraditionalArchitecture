using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoContentManager : MonoBehaviour
{
    public List<InterviewItem> interviewItems;
    public Image interviewImage;
    public List<Button> interviewButtons;
    public GameObject interviewPanel;
    public GameObject buttonPanel;
    public InterviewItem selectInterview;
    public VideoPlayer video;
    public GameObject videoScreen;
    Transform selectPanel;
    public void SetInterviewItem(int index)
    {
        interviewImage.sprite = interviewItems[index].interviewImage;
        selectPanel = interviewPanel.transform.GetChild(index + 2);
        selectPanel.GetChild(0).GetComponentInChildren<Text>().text = "전체 영상 보기";
        for (int i=0;i<interviewItems[index].interviewTextList.Count;i++)
        {
            selectPanel.GetChild(i+1).GetComponentInChildren<Text>().text = interviewItems[index].interviewTextList[i];
        }
        selectPanel.gameObject.SetActive(true);
        interviewPanel.SetActive(true);
        selectInterview = interviewItems[index];
    }

    public void PlayInterviewVideo(int index)
    {
        //Debug.Log(Resources.Load<VideoClip>(selectInterview.interviewURLList[index]));
        //Debug.Log(Resources.Load<VideoClip>(selectInterview.interviewURLList[index])==null);
        video.clip = Resources.Load<VideoClip>(selectInterview.interviewURLList[index]);
        video.Play();
        videoScreen.SetActive(true);
        video.loopPointReached += StopVideo;
    }
    public void StopVideo(VideoPlayer video)
    {
        video.Stop();
        videoScreen.SetActive(false);
    }
    public void HideSelectPanel()
    { 
        selectPanel.gameObject.SetActive(false);
        selectPanel = null;
    }
    [Serializable]
    public class InterviewItem
    {
        public Sprite interviewImage;
        public List<string> interviewTextList;
        public List<string> interviewURLList;
    }
}

