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

        //애니메이션이 실행중이지 않을때만
        if (animmanager.isAnimation == false) {
                        
            //애니메이션 실행중일때
            animmanager.isAnimation = true;
            AudioSource Mainaudio = GameObject.Find("group2").GetComponent<AudioSource>();
            Mainaudio.Stop();
            audioSource = GetComponent<AudioSource>();
            anim = this.GetComponent<Animation>();
            anim.Play();
            audioSource.Play();
            Invoke("setAnimManager", time);                             //9초 후에 Isnamation을 false로 만들고, 깜빡깜빡 거림
                      

            foreach (GameObject g in BlinkOBJ)                          //클릭되면 깜빡깜빡거리는 애니메이션 종료
            {
                g.GetComponent<Animation>().Play("BlinkIdle");
            }

            ClickManager clickmanager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
           
            if (isclicked == false)                                     //한번도 클릭되지 않은것을 클릭하면 ClickManager의 Number가 상승 (Number가 4가되면 "오방색 보러가기" 버튼 생성)
            {
                clickmanager.Number++;
                isclicked = true;
            }

            Subtitle subtitle = GameObject.Find("SubtitleManager_DC").GetComponent<Subtitle>();
            subtitle.text.text = str;
            subtitle.subtitleOn(str);
        }
               
    }

    //깜빡깜빡 애니메이션 실행하고, Isanimation = false
    public void setAnimManager()
    {
        AnimManager animmanager = GameObject.Find("AnimManager").GetComponent<AnimManager>();
        animmanager.isAnimation = false;
        foreach (GameObject g in BlinkOBJ)
        {
            g.GetComponent<Animation>().Play();
        }
    }

    
    //트래킹 벗어나면 isclicked 초기화
    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //트래킹 시작
            {
                
            }
            else //트래킹 사라짐
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
