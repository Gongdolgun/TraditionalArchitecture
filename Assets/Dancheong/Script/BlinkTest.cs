using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTest : MonoBehaviour
{
    public float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if(0 < timer && timer < 1)
        {
            GetComponent<Renderer>().material.SetColor( "EmissionColor", Color.Lerp(GetComponent<Renderer>().material.color, Color.black, timer));
            Debug.Log(GetComponent<Renderer>().material.color);
        }

        else if(1 < timer && timer < 2)
        {
            GetComponent<Renderer>().material.SetColor("EmissionColor", Color.white);
            Debug.Log(GetComponent<Renderer>().material.color);

        }

        else
        {
            timer = 0;
        }


    }
}
