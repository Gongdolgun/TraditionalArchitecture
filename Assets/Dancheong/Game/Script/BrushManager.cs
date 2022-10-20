using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public GameObject Brush;

    [SerializeField]
    public bool isanimated = false;
    public float time = 0;

    private void Update()
    {
        if (Brush != null)
        {
            isanimated = true;
            time = time + Time.deltaTime;

            if (time < 0.5f) { 
                if(Brush.name == "Scale_Small")
                {
                    GetComponent<Animation>().Play("Brush_S");
                }

                else if(Brush.name == "Scale_Middle")
                {
                    GetComponent<Animation>().Play("Brush_M");
                }
            
                else if (Brush.name == "Scale_Big")
                {
                    GetComponent<Animation>().Play("Brush_L");
                }
            
                else if (Brush.name == "Eraser")
                {
                    GetComponent<Animation>().Play("Eraser");
                }
            }

            else
            {
                time = 0;
                isanimated = false;
                Brush = null;
            }
        }
    }
}
