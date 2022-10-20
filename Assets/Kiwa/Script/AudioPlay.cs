using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public GameObject KiwaCanvas;
    public AudioClip audioclip;
    
    public void btnClick()
    {
        KiwaCanvas.GetComponent<AudioSource>().clip = audioclip;
        KiwaCanvas.GetComponent<AudioSource>().Play();
    }
}
