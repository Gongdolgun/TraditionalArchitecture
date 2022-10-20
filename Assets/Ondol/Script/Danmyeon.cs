using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmyeon : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
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
    }

    public void animPlay()
    {
        B_ON.GetComponent<Animation>().Play("FadeOut");
        
    }
}
