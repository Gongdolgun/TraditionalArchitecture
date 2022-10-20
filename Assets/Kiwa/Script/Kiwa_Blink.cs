using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwa_Blink : MonoBehaviour
{
    public GameObject[] BlinkOBJ;
    public GameObject[] NotBlink;
    public RuntimeAnimatorController animcontroller;

    public void BtnClick()
    {
        foreach(GameObject g in BlinkOBJ)
        {
            g.GetComponent<Animator>().runtimeAnimatorController = animcontroller;
        }

        foreach(GameObject g in NotBlink)
        {
            g.GetComponent<Animator>().runtimeAnimatorController = null;
        }
    }
}
