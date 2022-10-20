using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject VideoExists;
    /*[SerializeField]
    string curFile = @"C:\Temp\test";

    public void Start()
    {
        if (System.IO.Directory.Exists(curFile))
        {
            Debug.Log("File Exist");
        }

        else
        {
            Debug.Log("File doesen't exist");
        }    
    }*/

    public void btnClick()
    {
        VideoExists.SetActive(false);
        UICanvas.SetActive(true);
    }
}
