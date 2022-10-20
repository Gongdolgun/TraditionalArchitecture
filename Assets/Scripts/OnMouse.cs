using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public AnimationClip aniclip;
    public Animation anim;
    public AudioClip audioNarration;
    public PlayAnim player;
    public Subtitle_JJH subti;
    public string str;

    private void OnMouseUp()
    {
        //StopAllCoroutines();
        if (player.CanAnimate)
        {
            anim.clip = aniclip;
            anim.Play();
            player.DestroyBlinkingObjects();
            player.CanAnimate = false;
            player.audiosource.clip = audioNarration;
            player.audiosource.Play();
            subti.subtitleOn(str);
            StartCoroutine(WaitingAudio(anim.clip.length));
        }
        else
        {
            Debug.Log("Ω««‡¡ﬂ");
        }
    }
    IEnumerator WaitingAudio(float time)
    {
        yield return new WaitForSeconds(time);
        player.CanAnimate = true;
        player.AddBlinkingObjects();
        //subti.subtitleOff();
    }
}
