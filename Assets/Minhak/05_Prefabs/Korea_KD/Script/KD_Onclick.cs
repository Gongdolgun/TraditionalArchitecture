using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Onclick : MonoBehaviour
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
        KD_Animation anim = GameObject.Find("korea_AR_L2_V1").GetComponent<KD_Animation>();
        anim.isclicked = true;
        Destroy(this);

    }
}
