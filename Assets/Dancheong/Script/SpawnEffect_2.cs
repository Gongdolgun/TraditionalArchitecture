using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect_2 : MonoBehaviour
{
    bool onRenderer = false;
    bool OldRenderer = true;
    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;

    ParticleSystem ps;
    public float timer = 0;
    Renderer _renderer;

    int shaderProperty;

    void Start()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        //ps = GetComponentInChildren <ParticleSystem>();

        //var main = ps.main;
        //main.duration = spawnEffectTime;

        //ps.Play();

    }

    void Update()
    {
        if (timer < spawnEffectTime + pause)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //ps.Play();
            //timer = 0;
        }

        Renderer r = GetComponent<Renderer>();
        onRenderer = r.enabled;
        if (OldRenderer != onRenderer)
        {
            if (onRenderer == true) //트래킹 시작
            {

            }
            else //트래킹 사라짐
            {
                timer = 0.2f;

            }
        }
        OldRenderer = onRenderer;
        materialSet();

    }

    public void materialSet()
    {
        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
    }
}
