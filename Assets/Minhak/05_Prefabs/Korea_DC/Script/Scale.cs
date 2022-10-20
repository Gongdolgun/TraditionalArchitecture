using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    int i = 0;
    public float time;
    public float degree;
    public bool isclicked = false;
    bool onRenderer = false;
    bool OldRenderer = true;

    [Header("Object")]
    public GameObject [] object1;

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
            OnClick_Sphere[] OS = GetComponentsInChildren<OnClick_Sphere>(true);
            foreach (OnClick_Sphere g in OS)
            {
                Destroy(g);
            }
            time += Time.deltaTime;
            if (3< time && time < 3.3)
            {
                big(degree);
                
            }

            else if(time > 3.3 && time < 3.6)
            {
                big(degree * (-1));
            }

            if (4.1 < time && time < 4.4)
            {
                if (i == 0) i++;
                big(degree);

            }

            else if (4.4 < time && time < 4.7)
            {
                big(degree * (-1));
            }

            if (4.7 < time && time < 5)
            {
                if (i == 1) i++;
                big(degree);

            }

            else if (5 < time && time < 5.3)
            {
                big(degree * (-1));
            }

            if (5.3 < time && time < 5.6)
            {
                if (i == 2) i++;
                big(degree);

            }

            else if (5.6 < time && time < 5.9)
            {
                big(degree * (-1));
            }

            if (5.9 < time && time < 6.2)
            {
                if (i == 3) i++;
                big(degree);

            }

            else if (6.2 < time && time < 6.5)
            {
                big(degree * (-1));
            }

            else if(time > 6.5)
            {
                isclicked = false;
                time = 0;
            }
        }
    }

    public void big(float d)
    {
        object1[i].transform.localScale = object1[i].transform.localScale + new Vector3(d * Time.deltaTime, d * Time.deltaTime, d * Time.deltaTime);
        
    }

    public void small()
    {
        degree = degree * (-1);
    }

    public void TrackingStart()
    {
        foreach (GameObject g in object1)
        {
            g.AddComponent<OnClick_Sphere>();
        }
    }

    public void TrackingStop()
    {
        isclicked = false;
        time = 0;
        i = 0;
        foreach (GameObject g in object1)
        {
            Destroy(g.GetComponent <OnClick_Sphere> ());
        }
    }
}
