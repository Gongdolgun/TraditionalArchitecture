using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OpenTitleScene()
    {
        SceneManager.LoadScene("title_211207");
    }
    public void OpenARScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenPaintingScene()
    {
        SceneManager.LoadScene("DC_Painting");
    }
}
