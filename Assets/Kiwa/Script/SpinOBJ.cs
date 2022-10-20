using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOBJ : MonoBehaviour
{
    public GameObject JongRyu;
    // Start is called before the first frame update
    public void BtnClick()
    {
        JongRyu.GetComponent<Animation>().Blend("JongRyu_Spin");
    }
}
