using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setOBS : MonoBehaviour
{
    public GameObject[] ShowOBJ;
    public GameObject[] HideOBJ;
    public GameObject[] Sphere;
    public GameObject[] setInvoke;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void btnClick()
    {
        if (setInvoke != null)
        {
            foreach (GameObject g in setInvoke)
            {
                g.GetComponent<Anim>().CancelInvoke();
            }
        }

        //애니메이션,클릭 매니저 초기화
        AnimManager animmanager = GameObject.Find("AnimManager").GetComponent<AnimManager>();
        animmanager.isAnimation = false;

        ClickManager clickmanager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
        clickmanager.Number = 0;

        //단청, 오방색 초기화
        foreach (GameObject g in ShowOBJ)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in HideOBJ)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in Sphere)
        {
            g.GetComponent<SpawnEffect_2>().timer = 0.2f;
            g.GetComponent<SpawnEffect_2>().materialSet();
        }

    }
}
