using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInvisible : MonoBehaviour
{
    float timer = 0;
    public GameObject[] Visible;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>20)
        {
            foreach(GameObject g in Visible)
            {
                g.SetActive(true);
            }
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }
}
