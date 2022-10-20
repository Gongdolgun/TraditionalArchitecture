﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public string targetScene;
    public void GotoScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
