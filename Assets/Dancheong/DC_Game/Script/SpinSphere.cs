using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSphere : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    public void btnUP()
    {
        transform.Rotate(Vector3.up * 30);
    }

    public void btnDown()
    {
        transform.Rotate(Vector3.up * -30);

    }
}
