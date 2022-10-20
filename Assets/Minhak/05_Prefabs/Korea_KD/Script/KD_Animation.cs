using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class KD_Animation : MonoBehaviour
{
    public float time = 0;
    bool onRenderer = false;
    bool OldRenderer = true;
    public bool isclicked;
    public int listnum = 0;
    public float speed = 0.02f;


    [Header("속성값")]
    public List<Anim_Object> myItem = new List<Anim_Object>();


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
                TrackingStart();
            }
            else //트래킹 사라짐
            {
                TrackingStop();
            }
        }
        OldRenderer = onRenderer;

        if (isclicked == true) 
        {
            KD_Onclick[] OS = GetComponentsInChildren<KD_Onclick>(true);
            foreach (KD_Onclick g in OS)
            {
                Destroy(g);
            }


            time += Time.deltaTime;

            if (myItem[listnum].startTime < time && time < 4) 
            {                
                myItem[listnum].KD_Object.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            else if ((4 + myItem[listnum].startTime) < time && time < 8)
                myItem[listnum].KD_Object.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    public void TrackingStart()
    {
        myItem[listnum].KD_Object.AddComponent<KD_Onclick>();
    }

    public void TrackingStop()
    {
        time = 0;
        isclicked = false;
        /*foreach (GameObject g in KD_Object)
        {
            g.transform.position = new Vector3(0, 0, 0);
        }*/
    }
    
    public void IncreaseArrayNum()
    {
        listnum++;
    }
    
    [Serializable]
    public class Anim_Object
    {
        public GameObject KD_Object;
        public float startTime;
        public int num;
    }
}
