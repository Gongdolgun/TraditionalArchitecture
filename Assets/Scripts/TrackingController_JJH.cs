using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TrackingController_JJH : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public AudioSource audio;
    public AudioClip startclip;
    public Subtitle_JJH subti;
    public string str;
    public SpawnEffect spef;

    // Update is called once per frame
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //트래킹 시작
            {
                foreach (GameObject g in ShowOBJ)
                {

                    g.SetActive(true);
                    if (startclip != null)
                    {
                        audio.clip = startclip;
                        audio.Play();
                        subti.subtitleOn(str);
                        StartCoroutine(WaitAudio(audio.clip.length));
                    }
                }
            }
            else //트래킹 사라짐
            {
                foreach (GameObject g in HideOBJ)
                {
                    BlinkObjects[] blinkObjects = GameObject.FindObjectsOfType<BlinkObjects>();
                    foreach (BlinkObjects o in blinkObjects)
                    {
                        Debug.Log(blinkObjects);
                        o.ObjRenderer.material.color = Color.white;
                        Destroy(o);  //아웃라인 모두 지우기
                    }
                    g.SetActive(false);
                    audio.Stop();
                    if(spef != null)spef.timer = 0;
                    StopAllCoroutines();
                }
            }
        }
        OldRenderer = onRenderer;
    }
    IEnumerator WaitAudio(float time)
    {
        yield return new WaitForSeconds(time);
        //subti.subtitleOff();
    }
}