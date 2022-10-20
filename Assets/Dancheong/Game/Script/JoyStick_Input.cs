using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick_Input : MonoBehaviour
{
    public Joystick joystick;

    void Update()
    {
        transform.Rotate(joystick.input.y * Vector3.up * 1f);
    }
}
