using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBtn : MonoBehaviour
{
    public GameObject Gongpo;
    Animation anim;
    public void UpBtnClick()
    {
        anim = Gongpo.GetComponent<Animation>();
        anim.Play("GongpoAnim");
    }

    public void DownBtnClick()
    {
        anim = Gongpo.GetComponent<Animation>();
        anim.Play("GongpoReverse");
    }
}
