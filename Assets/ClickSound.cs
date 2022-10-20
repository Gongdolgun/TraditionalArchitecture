using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    AudioSource audiosource;

    public void BtnClick()
    {
        GetComponent<AudioSource>().Play();
    }
}
