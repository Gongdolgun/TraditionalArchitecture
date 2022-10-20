using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    Animation anim;
    public AudioSource audioSource;
    public float time;
    public GameObject[] BlinkOBJ;
    public bool isclicked = false;
    bool onRenderer = false;
    bool OldRenderer = true;
    public string str;

    // Start is called before the first frame update
    void start()
    {

    }

    private void OnMouseDown()
    {
        AnimManager animmanager = GameObject.Find("AnimManager").GetComponent<AnimManager>();

        //�ִϸ��̼��� ���������� ��������
        if (animmanager.isAnimation == false) {
                        
            //�ִϸ��̼� �������϶�
            animmanager.isAnimation = true;
            AudioSource Mainaudio = GameObject.Find("group2").GetComponent<AudioSource>();
            Mainaudio.Stop();
            audioSource = GetComponent<AudioSource>();
            anim = this.GetComponent<Animation>();
            anim.Play();
            audioSource.Play();
            Invoke("setAnimManager", time);                             //9�� �Ŀ� Isnamation�� false�� �����, �������� �Ÿ�
                      

            foreach (GameObject g in BlinkOBJ)                          //Ŭ���Ǹ� ���������Ÿ��� �ִϸ��̼� ����
            {
                g.GetComponent<Animation>().Play("BlinkIdle");
            }

            ClickManager clickmanager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
           
            if (isclicked == false)                                     //�ѹ��� Ŭ������ �������� Ŭ���ϸ� ClickManager�� Number�� ��� (Number�� 4���Ǹ� "����� ��������" ��ư ����)
            {
                clickmanager.Number++;
                isclicked = true;
            }

            Subtitle subtitle = GameObject.Find("SubtitleManager_DC").GetComponent<Subtitle>();
            subtitle.text.text = str;
            subtitle.subtitleOn(str);
        }
               
    }

    //�������� �ִϸ��̼� �����ϰ�, Isanimation = false
    public void setAnimManager()
    {
        AnimManager animmanager = GameObject.Find("AnimManager").GetComponent<AnimManager>();
        animmanager.isAnimation = false;
        foreach (GameObject g in BlinkOBJ)
        {
            g.GetComponent<Animation>().Play();
        }
    }

    
    //Ʈ��ŷ ����� isclicked �ʱ�ȭ
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //Ʈ��ŷ ����
            {
                
            }
            else //Ʈ��ŷ �����
            {
                Anim anim = GameObject.Find("gachile").GetComponent<Anim>();
                Anim anim1 = GameObject.Find("gootgi").GetComponent<Anim>();
                Anim anim2 = GameObject.Find("moro").GetComponent<Anim>();
                Anim anim3 = GameObject.Find("geum").GetComponent<Anim>();

                anim.isclicked = false;
                anim1.isclicked = false;
                anim2.isclicked = false;
                anim3.isclicked = false;


                CancelInvoke();
            }
        }
        OldRenderer = onRenderer;
    }
}
