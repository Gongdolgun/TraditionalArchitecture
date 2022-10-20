using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeonChae : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject[] BlinkPrefab;
    public RuntimeAnimatorController blinkidle;
    public GameObject B_ON;

    public void BtnClick()
    {
        foreach (GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in BlinkPrefab)
        {
            g.GetComponent<Animator>().runtimeAnimatorController = blinkidle;
        }

        AudioSource audiosource = GameObject.Find("Ondol_Canvas").GetComponent<AudioSource>();
        audiosource.Stop();

    }

    public void animPlay()
    {
        B_ON.GetComponent<Animation>().Play("FadeIn");
    }
}
