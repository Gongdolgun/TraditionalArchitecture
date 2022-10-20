using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//������ ������Ʈ 6�� ������ ���� ��Ʈ�� 


public class MainController2 : MonoBehaviour
{
    public Text textNarration;
    public Text textLog;
    public string CurrentNarration = "";
    public int iter; //��ġ�ϸ� ���� �ƿ����� ����
    public AudioSource myAudio;
    bool onRenderer = false;
    bool OldRenderer = true;
    public Animation anim;
    public Image image;

    //������ �� ����
    public GameObject[] defaultShow;
    public GameObject[] defaultHide;
    Coroutine co;
    //
    [Header("���� ��� 0���� ���¿� ")]
    public List<Item> myItem = new List<Item>(); //��ü ������ ���⿡ ����Ͽ� ����, �ϴܿ� Ŭ���� Ȯ��

    void Start()
    {
        myAudio = this.GetComponent<AudioSource>();
        SetState(0);
        image.enabled = false;
    }
    private void Update()
    {
        CurrentNarration = CurrentNarration.Replace(";", "\n");
        //�������� �������� ���°� ���ϰ� ������ ���� ������, ������ �����߿�
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //Ʈ��ŷ ����
            {
                SetState(0);
                Debug.Log("create");
            }
            else //Ʈ��ŷ �����
            {
                Reset();
                Debug.Log("destroy");
                image.enabled = false;
            }
        }
        OldRenderer = onRenderer;
    }

    //���º���� ����
    public void SetState(int i)
    {

        if (i == 0 || i == 1)
        {
            anim = myItem[i].animObject.GetComponent<Animation>();
            image.enabled = true;
            if (i == iter) return; //�ε����� ������ ���� ����
            iter = i; //���� �ε��� ����;
            textLog.text = "SetState" + i;
            if (myItem[i].toShow) myItem[i].toShow.SetActive(true);

            if (myItem[i].audioNarration != null) myAudio.clip = myItem[i].audioNarration;
            if (myItem[i].animation != null) anim.clip = myItem[i].animation;
            myAudio.Play();
            anim.Play();
            co = StartCoroutine(SetNext(myAudio.clip.length));

            if (myItem[i].textNarration != "")
            {
                //CurrentNarration = myItem[i].textNarration;
                textNarration.text = myItem[i].textNarration;
            }
        }
        else
        {
            anim = myItem[i].animObject.GetComponent<Animation>();

            //if(i == 0) Reset();
            if (i == iter) return; //�ε����� ������ ���� ����
            iter = i; //���� �ε��� ����;
            textLog.text = "SetState" + i;

            if (myItem[i].toShow) myItem[i].toShow.SetActive(true);
            if (myItem[i].toBlink != null)
            {
                foreach (GameObject g in myItem[i].toBlink)
                {
                    g.AddComponent<BlinkObjects>(); //���߿� ������� ���
                }
            }
            if (myItem[i].toTouch != null)
            {
                foreach (GameObject TouchObject in myItem[i].toTouch)
                {
                    TouchObject.AddComponent<AudioPlay>();
                    TouchObject.AddComponent<BoxCollider>();
                }
            }
            //����� ��¿�
            if (myItem[i].toHide) myItem[i].toHide.SetActive(false);
            if (myItem[i].audioNarration != null) myAudio.clip = myItem[i].audioNarration;
            if (myItem[i].animation != null) anim.clip = myItem[i].animation;
            if (myItem[i].textNarration != "")
            {
                CurrentNarration = myItem[i].textNarration;
                //textNarration.text = "�����̴� �κ��� Ŭ���غ�����.";
            }
        }
    }

    public void PlayAudio()
    {
        myAudio.Play(); //�����̼� �÷���
        if (myItem[iter].HideOBJ)
        {
            myItem[iter].HideOBJ.SetActive(false);
        }
        foreach (GameObject g in myItem[iter].toBlink)
        {
            Destroy(g.GetComponent<BlinkObjects>());//�ƿ����� ����
            Destroy(g.GetComponent<AudioPlay>());
            Destroy(g.GetComponent<BoxCollider>());
        }
        textNarration.text = CurrentNarration;
        if (myItem[iter].animation) //�ִϸ��̼� ����
        {
            anim.Play();
        }
        co = StartCoroutine(SetNext(myAudio.clip.length)); //����� ���̸�ŭ ��ٸ�
    }
    IEnumerator SetNext(float time)
    {
        Debug.Log("SetNext    " + time);

        anim.clip = myItem[iter].ResetAnim;
        yield return new WaitForSeconds(time);
        textNarration.text = "";
        SetState(iter + 1);
    }

    //����� ���߰� ������ ���ְ� �ִϸ��̼� ����
    private void Reset()
    {
        myAudio.Stop();
        //anim.Stop();
        if (myItem[iter].animation != null) anim.clip = myItem[iter].ResetAnim;
        anim.Play();
        Debug.Log("reset  " + this.name);
        BlinkObjects[] BlinkObjectss = GetComponentsInChildren<BlinkObjects>(true);
        AudioPlay[] AudioPlays = GetComponentsInChildren<AudioPlay>(true);
        if (co != null) StopCoroutine(co);  //�ڷ�ƾ �����
        foreach (BlinkObjects o in BlinkObjectss)
        {
            Destroy(o);  //�ƿ����� ��� �����
        }
        foreach (AudioPlay a in AudioPlays)
        {
            Destroy(a); //������÷��̾� ��� �����
        }
        foreach (GameObject g in defaultShow)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in defaultHide)
        {
            g.SetActive(false);
        }
        textNarration.text = "";
        iter = -1;

    }

    [Serializable]
    public class Item
    {
        //���������� ���̰��ؾ��ϴ� ������Ʈ
        public GameObject toShow;
        //�����̰� �ؾ��ϴ� ������Ʈ
        public GameObject[] toBlink;
        //Ŭ���ϴ� ������Ʈ
        public GameObject[] toTouch;
        //���ܾ� �ϴ� ������Ʈ
        public GameObject toHide;
        //�����̼�
        public AudioClip audioNarration;
        //ȭ�鿡 ���̴� �����̼� �ؽ�Ʈ
        public String textNarration;
        //�ִϸ��̼� �ִϸ�����
        public AnimationClip animation;
        //�ִϸ������� Ʈ����
        public string animationTrigger;
        //�÷����� �ִϸ��̼��� ������Ʈ
        public GameObject animObject;
        //���� �ִϸ��̼�
        public AnimationClip ResetAnim;
        //�ִϸ��̼� ���� �� ������Ʈ
        public GameObject HideOBJ;
    }
}
