using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OD_MainBtn : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public AudioClip audioClip;

    public void BtnClick()
    {
        foreach(GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }

        foreach(GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }

        AudioSource audiosource = GameObject.Find("Ondol_Canvas").GetComponent<AudioSource>();
        audiosource.clip = audioClip;
        audiosource.Play();
    }
}
