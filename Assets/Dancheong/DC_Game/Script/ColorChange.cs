using Es.InkPainter;
using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public GameObject Colorprefab;
    public Color color;

    public void btnclick() 
    {
        Colorprefab.GetComponent<MousePainter>().brush.brushColor = color;
    }

    public void BrushBig()
    {
        Colorprefab.GetComponent<MousePainter>().brush.brushScale += 0.005f;
    }
    public void BrushSmall()
    {
        Colorprefab.GetComponent<MousePainter>().brush.brushScale -= 0.005f;
    }

    public void ResetAll()
    {
        foreach (var canvas in FindObjectsOfType<InkCanvas>())
            canvas.ResetPaint();
    }
}
