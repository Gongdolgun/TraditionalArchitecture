using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObjects : MonoBehaviour
{
    public Color color = new Color(0.77f, 0.55f, 0, 0.8f);
    public Renderer ObjRenderer;
    Renderer renderer;
    private int Count = 50;
    bool Increase = false;
    Color mainColor = new Color(0, 0, 0, 0f);
    Color defaultColor;
    public Color blinkColor;
    // Start is called before the first frame update
    void Start()
    {  
        ObjRenderer = GetComponent<Renderer>();
        renderer = ObjRenderer;
        defaultColor = renderer.material.color;
        ObjRenderer.material.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if (Increase)
        {
            ObjRenderer.material.SetColor("_EmissionColor", Color.Lerp(color, mainColor,Count * 0.01f));
            Count++;
            if (Count > 100) Increase = false;
        }
        else
        {
            ObjRenderer.material.SetColor("_EmissionColor", Color.Lerp(color, mainColor, Count * 0.01f));
            Count--;
            if (Count < 0) Increase = true;
        }
    }
    private void OnDestroy()
    {
        Debug.Log("?");
        ObjRenderer.material.color = defaultColor;
        ObjRenderer.material.DisableKeyword("_EMISSION");
    }
}
