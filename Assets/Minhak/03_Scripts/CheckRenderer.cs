using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRenderer : MonoBehaviour
{
    bool onRenderer = true;
    bool OldRenderer = false;
    public GameObject source;
    public GameObject Instance;
    // Update is called once per frame
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer  )
        {
            
            if (onRenderer == true)
            {
                if (!Instance) { Instance = Instantiate(source); }
                Debug.Log("create");
            }
            else
            {
                if(Instance) Destroy(Instance);
                Debug.Log("destroy");
            }
        }
         
        OldRenderer = onRenderer;
    }
}
