using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_BackBtn : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;

    public void BtnClick()
    {
        foreach (GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }

        foreach(GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }

        AudioSource Canvasaudio = GameObject.Find("GP_Canvas").GetComponent<AudioSource>();
        Canvasaudio.Stop();
    }
}
