using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn_JJH : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject[] BlinkOBJ;
    public SpawnEffect spef;
    public Subtitle_JJH subti;
    public string str;
    BlinkObjects bo;
    bool ClickAgain = true;
    public void btnClick()
    {
        audioSource.Stop();
        if (ClickAgain)
        {
            BlinkObjects[] blinkObjects = GameObject.FindObjectsOfType<BlinkObjects>();
            foreach (BlinkObjects o in blinkObjects)
            {
                Debug.Log(blinkObjects != null);
                o.ObjRenderer.material.color = Color.white;
                Debug.Log("Destroyed");
                Destroy(o);  //아웃라인 모두 지우기
            }
        }
        if (spef != null)spef.timer = 0;
        foreach (GameObject g in ShowOBJ)
        {
            Debug.Log("2");
            g.SetActive(true);
        }

        foreach (GameObject g in HideOBJ)
        {
            Debug.Log("3");
            g.SetActive(false);
        }
        foreach(GameObject g in BlinkOBJ)
        {
            Debug.Log("4");
            bo = g.AddComponent<BlinkObjects>();
            Debug.Log("Created");
            bo.color = new Color(0.8f, 0.8f, 0, 1);
        }
        if (audioSource.isPlaying) audioSource.Stop();
        if(clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        if(str != "" && subti != null)
        {
            Debug.Log("5");
            subti.subtitleOn(str);
        }
        StartBtn_JJH[] startBtns = GameObject.FindObjectsOfType<StartBtn_JJH>();
        foreach(StartBtn_JJH sb in startBtns)
        {
            sb.ClickAgain = true;
        }
        this.ClickAgain = false;
    }
}