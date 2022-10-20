using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TF_Cylinder7 : MonoBehaviour
{
    float time;
    public float speed;
    public float scale;
    public GameObject[] gameobject;
    bool isclicked = false;
    public float Starttime = 0;
    public float Endtime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isclicked = true;
        }

        //transform.Rotate(degree * Time.deltaTime, 0, 0);

        if (isclicked == true)
        {
            /*foreach (GameObject g in gameobject)
            {
                g.SetActive(false);
            }*/
            time = time + Time.deltaTime;
            if (time < Starttime)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.localScale = transform.localScale + new Vector3(scale * Time.deltaTime, scale * Time.deltaTime, scale * Time.deltaTime);
            }

            else if (Endtime < time && time < Endtime + 1)
            {
                transform.Translate(Vector3.right * ((-1) * speed) * Time.deltaTime);
                transform.localScale = transform.localScale + new Vector3((scale * (-1)) * Time.deltaTime, (scale * (-1)) * Time.deltaTime, (scale * (-1)) * Time.deltaTime);
                foreach (GameObject g in gameobject)
                {
                    g.SetActive(true);
                }
            }

            else if (time > Endtime + 1)
            {
                isclicked = false;
            }
        }

        /*else if (isclicked == false)
        {
            foreach (GameObject g in gameobject)
            {
                g.SetActive(true);
            }
        }*/
    }
}
