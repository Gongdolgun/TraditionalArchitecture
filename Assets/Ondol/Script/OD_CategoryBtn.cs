using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OD_CategoryBtn : MonoBehaviour
{
    public GameObject[] blinkprefabs;
    public GameObject[] notBlink;
    public RuntimeAnimatorController animController;
    public RuntimeAnimatorController animIdle;
    public AudioClip audioClip;

    public void btnClick()
    {
        foreach(GameObject g in blinkprefabs)
        {
            g.SetActive(true);
            g.GetComponent<Animator>().runtimeAnimatorController = animController;
        }
        foreach (GameObject g in notBlink)
        {
            g.SetActive(false);
            g.GetComponent<Animator>().runtimeAnimatorController = animIdle;
        }

        AudioSource audiosource = GameObject.Find("Ondol_Canvas").GetComponent<AudioSource>();
        audiosource.clip = audioClip;
        audiosource.Play();
    }
}
