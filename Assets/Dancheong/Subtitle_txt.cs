using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle_txt : MonoBehaviour
{
    public Text txt;
    public string str;

    public void setText()
    {
        txt.text = str;
        
    }
}
