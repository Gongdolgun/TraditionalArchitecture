using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_joysitick : MonoBehaviour
{
    public Joystick joystick;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position += new Vector3(0, 0, joystick.input.y * 0.5f * -1);

        if (transform.position.z < 3.5f)
        {
            transform.position = new Vector3(0, 0, 3.5f);
        }

        if (transform.position.z > 7f)
        {
            transform.position = new Vector3(0, 0, 7f);
        }
    }
}
