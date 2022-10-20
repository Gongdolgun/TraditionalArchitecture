using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject DC_UI;
    public int Number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Number == 4)
        {
            Invoke("DC_UI_Setactive", 9f);
        }
    }

    public void DC_UI_Setactive()
    {
        DC_UI.SetActive(true);

    }
}
