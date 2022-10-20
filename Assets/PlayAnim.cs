using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//생성된 오브젝트 6개 각각의 메인 컨트롤 


public class PlayAnim : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;
    Animation anim;
    public bool CanAnimate = false;
    public AnimationClip clip;
    public GameObject[] toBlink;
    public AudioSource audiosource;

    Coroutine co;

    [Header("Blink Color")]
    public Color inputColor;

    public void Start()
    {
        anim = GetComponent<Animation>();
        if (clip != null)
        {
            anim.clip = clip;
            anim.Play();
            Debug.Log(anim.clip.name);
            AddBlinkingObjects();
            co = StartCoroutine(WaitingAnim(anim.clip.length));
        }
    }

    public void AddBlinkingObjects()
    {
        for(int i = 0; i<toBlink.Length;i++)
        {
            toBlink[i].AddComponent<BlinkObjects>();
        }
    }



    public void DestroyBlinkingObjects()
    {
        BlinkObjects[] blinkObjects = GetComponentsInChildren<BlinkObjects>(true);
        foreach (BlinkObjects o in blinkObjects)
        {
            o.ObjRenderer.material.color = Color.white;
            Destroy(o);  //아웃라인 모두 지우기
        }
    }

    IEnumerator WaitingAnim(float time)
    {
        yield return new WaitForSeconds(time);
        CanAnimate = true;
    }

    //오디오 멈추고 깜박임 없애고 애니메이션 멈춤
    private void Reset()
    {
        anim.Play();
        Debug.Log("reset  " + this.name);
        BlinkObjects[] blinkObjects = GetComponentsInChildren<BlinkObjects>(true);
        AudioPlay[] AudioPlays = GetComponentsInChildren<AudioPlay>(true);
        if (co != null) StopCoroutine(co);  //코루틴 지우기
        foreach (BlinkObjects o in blinkObjects)
        {
            o.ObjRenderer.material.color = Color.white;
            Destroy(o);  //아웃라인 모두 지우기
        }
        foreach (AudioPlay a in AudioPlays)
        {
            Destroy(a); //오디오플레이어 모두 지우기
        }

    }
}
