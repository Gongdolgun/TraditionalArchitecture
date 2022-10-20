using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_MainBtn : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public AudioClip audioclip;

    public void btnClick()
    {
        foreach(GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }

        AudioSource canvasaudio = GameObject.Find("GP_Canvas").GetComponent<AudioSource>();
        canvasaudio.clip = audioclip;
        canvasaudio.Play();
    }
}
