using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    int degree = 30;
    public float time;
    public GameObject RotState;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setRotation", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time < 5)
        //this.transform.Rotate(new Vector3(degree * Time.deltaTime, 0, 0));
        this.transform.Rotate(Vector3.up * degree * Time.deltaTime, Space.Self);

    }

    public void setRotation()
    {
        this.transform.Rotate(new Vector3(0, -150, 0));
    }
}
