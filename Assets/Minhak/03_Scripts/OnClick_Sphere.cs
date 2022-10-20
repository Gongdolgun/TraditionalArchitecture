using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick_Sphere : MonoBehaviour
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
        Scale scale = GameObject.Find("group4").GetComponent<Scale>();
        scale.isclicked = true;
        Destroy(this);
    }
}
