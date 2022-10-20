using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryBtn : MonoBehaviour
{
    public RuntimeAnimatorController animCP;
    public GameObject[] BlinkOBJ;
    public GameObject[] NotBlink;
    public AudioClip audioclip;

    public void BtnClick()
    {
        foreach(GameObject g in BlinkOBJ) 
        { 
            g.GetComponent<Animator>().runtimeAnimatorController = animCP;
        }

        foreach(GameObject g in NotBlink)
        {
            g.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        AudioSource audiosource = GameObject.Find("GP_Canvas").GetComponent<AudioSource>();
        audiosource.clip = audioclip;
        audiosource.Play();

    }
}
