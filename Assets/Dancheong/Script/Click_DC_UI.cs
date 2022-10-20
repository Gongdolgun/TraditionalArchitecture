using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_DC_UI : MonoBehaviour
{
    public GameObject[] Sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnClick()
    {
        foreach (GameObject g in Sphere)
        {
            g.GetComponent<SpawnEffect_2>().timer = 0.2f;
            g.GetComponent<SpawnEffect_2>().materialSet();
        }
    }
}
