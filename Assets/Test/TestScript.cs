using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;

    public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //Ʈ��ŷ ����
            {
                Debug.Log("Hello");
                prefab.SetActive(true);
                
            }
            else //Ʈ��ŷ �����
            {
                
            }
        }
        OldRenderer = onRenderer;

        prefab.transform.position = this.transform.position;
    }
}
