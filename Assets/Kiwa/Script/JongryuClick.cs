using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JongryuClick : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject prefab;

    public void Btnclick()
    {
        prefab.GetComponent<Animation>().Play("Jongryu_Idle");

        foreach (GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }

        
    }
}
