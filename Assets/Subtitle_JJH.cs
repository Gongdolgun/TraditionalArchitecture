using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle_JJH : MonoBehaviour
{
    public Text text;
    public GameObject subti;
    bool SubtitleisRunning = true;
    public AudioSource audio;
    public Vector3 defaultPosition = new Vector3(0, -50, 0);


    private void Update()
    {
        if (SubtitleisRunning)
        {
            text.transform.position += Vector3.up * 0.15f;
        }
    }

    public void subtitleOn(string subtitle)
    {
        subtitle = subtitle.Replace(";", "\n");
        subti.SetActive(true);
        SubtitleisRunning = true;
        text.transform.localPosition = defaultPosition;
        text.text = subtitle;
        if (audio.clip != null) StartCoroutine(WaitAudio(audio.clip.length));
    }

    //public void subtitleOff()
    //{
    //    subti.SetActive(false);
    //    text.transform.localPosition = defaultPosition;
    //}

    IEnumerator WaitAudio(float time)
    {
        yield return new WaitForSeconds(time);
        //subtitleOff();
    }
    
}
