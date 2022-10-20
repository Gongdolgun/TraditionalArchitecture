using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    /*public GameObject NextUI;
    public GameObject HideUI;*/

    public void btnClick()
    {
        foreach(GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }

        foreach(GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }
                
        /*NextUI.SetActive(true);
        NextUI.SetActive(false);*/
    }

}
