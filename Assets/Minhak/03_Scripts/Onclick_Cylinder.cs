using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onclick_Cylinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        TransformTest transformtest = GameObject.Find("group2").GetComponent<TransformTest>();
        transformtest.isclicked = true;
        Destroy(this);
    }
}
