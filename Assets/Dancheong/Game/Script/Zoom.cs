using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    Camera mainCamera;

    float touchesPrevPosDiffernce, touchesCurPosDifference, zoomModifier;

    Vector2 firstTouchPrevPos, secondTouchPrevPos;

    [SerializeField]
    float zoomModifierSpeed = 0.1f;

    [SerializeField]
    Text text;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {

        if(Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            touchesPrevPosDiffernce = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
            touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

            zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

            if (touchesPrevPosDiffernce > touchesCurPosDifference) // Zoom In
                mainCamera.transform.position += new Vector3(0, 0, 0.1f);
            if (touchesPrevPosDiffernce < touchesCurPosDifference) // Zoom Out
                mainCamera.transform.position -= new Vector3(0, 0, 0.1f);

        }

        if (transform.position.z < 3f)
        {
            transform.position = new Vector3(0, 0, 3f);
            Debug.Log("True");
        }

        if (transform.position.z > 6f)
        {
            transform.position = new Vector3(0, 0, 6f);
        }

        text.text = "Camera Position : " + mainCamera.transform.position.z;
    }
}
