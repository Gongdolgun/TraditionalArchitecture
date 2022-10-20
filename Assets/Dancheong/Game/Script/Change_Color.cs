using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class Change_Color : MonoBehaviour
{
    public GameObject paint;
    public Color color;
    public float scale;
    public GameObject Circle;
    public GameObject me;
    public Change_Color CC;
    public bool iserase;

    
    public void Paint_Color()
    {
        paint.GetComponent<P3dPaintSphere>().Color = color;
        if(Circle != null) Circle.transform.position = transform.position;

        if (CC.iserase == true)
        {
            GameObject.Find("Brush").GetComponent<Animation>().Play("Eraser_Reverse");
            CC.iserase = false;
        }
    }

    public void Paint_Scale()
    {
        paint.GetComponent<P3dPaintSphere>().Radius = scale;
        BrushManager brushmanager = GameObject.Find("Brush").GetComponent<BrushManager>();
        brushmanager.Brush = me;
    }

    public void Eraser()
    {
        paint.GetComponent<P3dPaintSphere>().Color = color;
        BrushManager brushmanager = GameObject.Find("Brush").GetComponent<BrushManager>();
        brushmanager.Brush = me;
        CC.iserase = true;
    }
}
