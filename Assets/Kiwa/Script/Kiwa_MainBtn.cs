using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwa_MainBtn : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    

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

        
    }
}
