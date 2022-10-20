using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwa_BackBtn : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject[] BlinkSet;

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

        foreach(GameObject g in BlinkSet)
        {
            g.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        AudioSource audiosource = GameObject.Find("Kiwa_Canvas").GetComponent<AudioSource>();
        audiosource.Stop();
    }
}
