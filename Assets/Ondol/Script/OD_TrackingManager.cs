using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OD_TrackingManager : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject[] blinkPrefab;
    public RuntimeAnimatorController blinkidle;
    public GameObject B_ON;

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
                foreach (GameObject g in ShowOBJ)
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

                foreach (GameObject g in blinkPrefab)
                {
                    g.GetComponent<Animator>().runtimeAnimatorController = blinkidle;
                }

                B_ON.GetComponent<Animation>().Play("Idle");
                AudioSource audiosource = GameObject.Find("Ondol_Canvas").GetComponent<AudioSource>();
                audiosource.Stop();

            }
        }
        OldRenderer = onRenderer;
    }
}
