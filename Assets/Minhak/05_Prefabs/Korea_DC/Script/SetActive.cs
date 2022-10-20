using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetActive : MonoBehaviour
{
    public float time = 0;
    public GameObject[] OBJ;
    public bool isClicked = false;
    public int i = 0;

    public List<Item> myItem = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        OBJ[i].AddComponent<OnClick_Cyl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked == true)
        {
            foreach(GameObject h in myItem[i].Hide)
            {
                //h.SetActive(false);
            }
            time += Time.deltaTime;
            if(time > myItem[i].audiolength + 1)
            {
                foreach(GameObject g in myItem[i].Hide)
                {
                    g.SetActive(true);
                }
                time = 0;
                i++;
                OBJ[i].AddComponent<OnClick_Cyl>();
                isClicked = false;
            }
        }
    }

    [Serializable]
    public class Item
    {
        public GameObject[] Hide;
        public float audiolength;

    }

}
