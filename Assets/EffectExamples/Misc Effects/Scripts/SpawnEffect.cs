using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    public GameObject[] btn;
    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;
    public GameObject roof;

    ParticleSystem ps;
    public float timer = 0;
    Renderer _renderer;

    int shaderProperty;

    public void Start()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        timer = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= spawnEffectTime + pause)
        {
            timer = 0;
            setBtnActive();
            roof.SetActive(false);
        }


        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer )));
        
    }
    void setBtnActive()
    {
        foreach (GameObject g in btn)
        {
            g.SetActive(true);
        }
    }

    public void materialSet()
    {
        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
    }
}