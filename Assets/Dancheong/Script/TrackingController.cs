using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackingController : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //트래킹 시작
            {
                foreach(GameObject g in ShowOBJ)
                {
                    g.SetActive(true);
                }
            }
            else //트래킹 사라짐
            {
                foreach (GameObject g in HideOBJ)
                {
                    g.SetActive(false);
                }
                AnimManager animmanager = GameObject.Find("AnimManager").GetComponent<AnimManager>();
                animmanager.isAnimation = false;

                ClickManager clickmanager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
                clickmanager.Number = 0;

                
            }
        }
        OldRenderer = onRenderer;
    }
}
