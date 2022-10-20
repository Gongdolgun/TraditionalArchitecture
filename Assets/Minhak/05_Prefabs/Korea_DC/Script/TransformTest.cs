using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransformTest : MonoBehaviour
{
    public float time;
    public bool isclicked = false;
    public int listNum;
    public float degree;
    bool onRenderer = false;
    bool OldRenderer = true;


    // Start is called before the first frame update

    [Header("속성값")]
    public List<Item> myItem = new List<Item>();
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //트래킹 시작
            {
                TrackingStart();
            }
            else //트래킹 사라짐
            {
                TrackingFail();
            }
        }
        OldRenderer = onRenderer;


        if (isclicked == true ) 
        {
            time = time + Time.deltaTime;

            //1초간 가운데로 가기
            if (time < myItem[listNum].Starttime)
            {
                Hide(listNum);

                myItem[listNum].ClickObject.transform.Translate(Vector3.right * myItem[listNum].speed * Time.deltaTime);
                myItem[listNum].ClickObject.transform.localScale = myItem[listNum].ClickObject.transform.transform.localScale + new Vector3(myItem[listNum].scale * Time.deltaTime, myItem[listNum].scale * Time.deltaTime, myItem[listNum].scale * Time.deltaTime);
            }

            //1초~Endtime까지 회전
            else if( myItem[listNum].Starttime < time && time < myItem[listNum].Endtime)
            {
                myItem[listNum].ClickObject.transform.Rotate(Vector3.up * degree * Time.deltaTime, Space.Self);
                myItem[listNum].isrotate = true;
            }
                
            else if (myItem[listNum].Endtime < time && time < myItem[listNum].Endtime +1)
            {
                //Rotate한만큼 다시 빼주기
                if (myItem[listNum].isrotate == true)
                {
                    myItem[listNum].ClickObject.transform.Rotate(new Vector3(0, myItem[listNum].Rotate, 0));
                    myItem[listNum].isrotate = false;
                }
                //myItem[listNum].ClickObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                //다시 제자리로 가기
                myItem[listNum].ClickObject.transform.Translate(Vector3.right * ((-1) * myItem[listNum].speed) * Time.deltaTime);
                myItem[listNum].ClickObject.transform.localScale = myItem[listNum].ClickObject.transform.transform.localScale + new Vector3((myItem[listNum].scale * (-1)) * Time.deltaTime, (myItem[listNum].scale * (-1)) * Time.deltaTime, (myItem[listNum].scale * (-1)) * Time.deltaTime);
                
                
            }

            else if (time > myItem[listNum].Endtime + 1)
            {
                //안보였던 오브젝트 보이기
                foreach (GameObject g in myItem[listNum].Hide)
                {
                    g.SetActive(true);
                }

                time = 0;
                listNum++;
                myItem[listNum].ClickObject.AddComponent<Onclick_Cylinder>();
                isclicked = false;
            }
        }
    }

    public void Hide(int i)
    {
        foreach (GameObject g in myItem[i].Hide)
        {
            g.SetActive(false);
        }
    }

    [Serializable]
    public class Item
    {
        public float speed;
        public float scale;
        public GameObject ClickObject;
        public GameObject[] Hide;
        public float Starttime = 0;
        public float Endtime = 0;
        public bool isrotate = false;
        public float Rotate;

    }

    public void TrackingStart()
    {
        myItem[0].ClickObject.AddComponent<Onclick_Cylinder>();
    }

    public void TrackingFail()
    {
        time = 0;
        listNum = 0;
        myItem[listNum].ClickObject.AddComponent<Onclick_Cylinder>();
        isclicked = false;

        foreach (GameObject g in myItem[listNum].Hide)
        {
            g.SetActive(true);
        }
    }

}
