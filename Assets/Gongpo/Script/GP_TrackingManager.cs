using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_TrackingManager : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject TrackingOBJ;
    public GameObject[] BlinkSet;
    Animation anim;
    
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
                anim = TrackingOBJ.GetComponent<Animation>();
                anim.Play();
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

                foreach(GameObject g in BlinkSet)
                {
                    g.GetComponent<Animator>().runtimeAnimatorController = null;
                }
            }
        }
        OldRenderer = onRenderer;
    }
}
