using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    public Animation anim;
    public AnimationClip reset;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        Invoke("AnimStop", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimStop()
    {
        anim.clip = reset;
        anim.Play();
    }
}
