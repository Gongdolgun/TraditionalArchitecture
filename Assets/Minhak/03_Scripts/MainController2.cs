using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//생성된 오브젝트 6개 각각의 메인 컨트롤 


public class MainController2 : MonoBehaviour
{
    public Text textNarration;
    public Text textLog;
    public string CurrentNarration = "";
    public int iter; //터치하면 지울 아웃라인 저장
    public AudioSource myAudio;
    bool onRenderer = false;
    bool OldRenderer = true;
    public Animation anim;
    public Image image;

    //리셋할 때 상태
    public GameObject[] defaultShow;
    public GameObject[] defaultHide;
    Coroutine co;
    //
    [Header("순차 목록 0번은 리셋용 ")]
    public List<Item> myItem = new List<Item>(); //전체 순서를 여기에 기록하여 진행, 하단에 클래스 확인

    void Start()
    {
        myAudio = this.GetComponent<AudioSource>();
        SetState(0);
        image.enabled = false;
    }
    private void Update()
    {
        CurrentNarration = CurrentNarration.Replace(";", "\n");
        //랜더러를 기준으로 상태가 변하고 켜지면 리셋 시행함, 리셋이 아주중요
        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //트래킹 시작
            {
                SetState(0);
                Debug.Log("create");
            }
            else //트래킹 사라짐
            {
                Reset();
                Debug.Log("destroy");
                image.enabled = false;
            }
        }
        OldRenderer = onRenderer;
    }

    //상태변경시 실행
    public void SetState(int i)
    {

        if (i == 0 || i == 1)
        {
            anim = myItem[i].animObject.GetComponent<Animation>();
            image.enabled = true;
            if (i == iter) return; //인덱스가 같으면 실행 안함
            iter = i; //현재 인덱스 저장;
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
            if (i == iter) return; //인덱스가 같으면 실행 안함
            iter = i; //현재 인덱스 저장;
            textLog.text = "SetState" + i;

            if (myItem[i].toShow) myItem[i].toShow.SetActive(true);
            if (myItem[i].toBlink != null)
            {
                foreach (GameObject g in myItem[i].toBlink)
                {
                    g.AddComponent<BlinkObjects>(); //나중에 지우려고 기록
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
            //오디오 출력용
            if (myItem[i].toHide) myItem[i].toHide.SetActive(false);
            if (myItem[i].audioNarration != null) myAudio.clip = myItem[i].audioNarration;
            if (myItem[i].animation != null) anim.clip = myItem[i].animation;
            if (myItem[i].textNarration != "")
            {
                CurrentNarration = myItem[i].textNarration;
                //textNarration.text = "깜박이는 부분을 클릭해보세요.";
            }
        }
    }

    public void PlayAudio()
    {
        myAudio.Play(); //나래이션 플레이
        if (myItem[iter].HideOBJ)
        {
            myItem[iter].HideOBJ.SetActive(false);
        }
        foreach (GameObject g in myItem[iter].toBlink)
        {
            Destroy(g.GetComponent<BlinkObjects>());//아웃라인 지움
            Destroy(g.GetComponent<AudioPlay>());
            Destroy(g.GetComponent<BoxCollider>());
        }
        textNarration.text = CurrentNarration;
        if (myItem[iter].animation) //애니메이션 시작
        {
            anim.Play();
        }
        co = StartCoroutine(SetNext(myAudio.clip.length)); //오디오 길이만큼 기다림
    }
    IEnumerator SetNext(float time)
    {
        Debug.Log("SetNext    " + time);

        anim.clip = myItem[iter].ResetAnim;
        yield return new WaitForSeconds(time);
        textNarration.text = "";
        SetState(iter + 1);
    }

    //오디오 멈추고 깜박임 없애고 애니메이션 멈춤
    private void Reset()
    {
        myAudio.Stop();
        //anim.Stop();
        if (myItem[iter].animation != null) anim.clip = myItem[iter].ResetAnim;
        anim.Play();
        Debug.Log("reset  " + this.name);
        BlinkObjects[] BlinkObjectss = GetComponentsInChildren<BlinkObjects>(true);
        AudioPlay[] AudioPlays = GetComponentsInChildren<AudioPlay>(true);
        if (co != null) StopCoroutine(co);  //코루틴 지우기
        foreach (BlinkObjects o in BlinkObjectss)
        {
            Destroy(o);  //아웃라인 모두 지우기
        }
        foreach (AudioPlay a in AudioPlays)
        {
            Destroy(a); //오디오플레이어 모두 지우기
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
        //숨겨진것을 보이게해야하는 오브젝트
        public GameObject toShow;
        //깜박이게 해야하는 오브젝트
        public GameObject[] toBlink;
        //클릭하는 오브젝트
        public GameObject[] toTouch;
        //숨겨야 하는 오브젝트
        public GameObject toHide;
        //나래이션
        public AudioClip audioNarration;
        //화면에 보이는 나래이션 텍스트
        public String textNarration;
        //애니메이션 애니메이터
        public AnimationClip animation;
        //애니메이터의 트리거
        public string animationTrigger;
        //플레이할 애니메이션의 오브젝트
        public GameObject animObject;
        //리셋 애니메이션
        public AnimationClip ResetAnim;
        //애니메이션 도중 끌 오브젝트
        public GameObject HideOBJ;
    }
}
