using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSet : MonoBehaviour
{
    public GameObject[] particle;
    public bool isclicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isclicked == true)
        {
            foreach (GameObject g in particle)
            {
                g.SetActive(true);
            }
        }

        if (isclicked == false)
        {
            foreach (GameObject g in particle)
            {
                g.SetActive(false);
            }
        }

    }

    private void OnMouseDown()
    {
        if(isclicked == false)
        {
            isclicked = true;
        }

        else if(isclicked == true)
        {
            isclicked = false;
        }

    }
}
