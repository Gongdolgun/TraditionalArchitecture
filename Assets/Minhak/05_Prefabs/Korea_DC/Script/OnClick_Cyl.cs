using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick_Cyl : MonoBehaviour
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
        SetActive setactive = GameObject.Find("group2").GetComponent<SetActive>();

        setactive.isClicked = true;

        Destroy(this);
    }
}
