using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private Renderer renderer;
    public Color color = new Color(0, 1f, 1f, 0.1f);
    public Renderer ObjRenderer;
    private int Count = 50;
    bool Increase = false;
    Color mainColor;
    public Color blinkColor;
    // Start is called before the first frame update
    void Start()
    {

        ObjRenderer = GetComponent<Renderer>();
        renderer = ObjRenderer;
        mainColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Increase)
        {
            ObjRenderer.material.color = Color.Lerp(ObjRenderer.material.color, mainColor, Count * 0.01f);

            Count++;
            if (Count > 50) Increase = false;
        }
        else
        {
            ObjRenderer.material.color = Color.Lerp(ObjRenderer.material.color, color, 1 - Count * 0.01f);
            Count--;
            if (Count < 0) Increase = true;
        }
    }
    private void OnDestroy()
    {
        ObjRenderer.material.color = mainColor;
    }

}
