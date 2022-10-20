using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Anim : MonoBehaviour
{
    private Animation anim;
    public string Anim_Name;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("WInput");
            anim.Play(Anim_Name);            
        }
    }

    private void OnMouseDown()
    {
        
    }
}
