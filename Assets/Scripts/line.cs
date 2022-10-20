using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public GameObject nameTag;
    public GameObject someOtherVector3;
    public GameObject someOtherOffset;
    GameObject _camera;
    public GameObject anchor;
    public GameObject targetObject;

    public LineRenderer lineRenderer;

    void Start()
    {
        _camera = Camera.main.gameObject;
    }

    void Update()
    {
        if(targetObject.activeSelf)
        {
            nameTag.SetActive(true);
            someOtherVector3.SetActive(true);
            Vector3[] positions = { nameTag.transform.position, someOtherVector3.transform.position };
            lineRenderer.SetPositions(positions);
            //anchor.transform.LookAt(_camera.transform.position, Vector3.up);
            someOtherOffset.transform.position = targetObject.transform.position;
        }
        else
        {
            nameTag.SetActive(false);
            someOtherVector3.SetActive(false);
        }
        
    }
}
