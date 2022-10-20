using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//������ ������Ʈ 6�� ������ ���� ��Ʈ�� 


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
            Destroy(o);  //�ƿ����� ��� �����
        }
    }

    IEnumerator WaitingAnim(float time)
    {
        yield return new WaitForSeconds(time);
        CanAnimate = true;
    }

    //����� ���߰� ������ ���ְ� �ִϸ��̼� ����
    private void Reset()
    {
        anim.Play();
        Debug.Log("reset  " + this.name);
        BlinkObjects[] blinkObjects = GetComponentsInChildren<BlinkObjects>(true);
        AudioPlay[] AudioPlays = GetComponentsInChildren<AudioPlay>(true);
        if (co != null) StopCoroutine(co);  //�ڷ�ƾ �����
        foreach (BlinkObjects o in blinkObjects)
        {
            o.ObjRenderer.material.color = Color.white;
            Destroy(o);  //�ƿ����� ��� �����
        }
        foreach (AudioPlay a in AudioPlays)
        {
            Destroy(a); //������÷��̾� ��� �����
        }

    }
}
