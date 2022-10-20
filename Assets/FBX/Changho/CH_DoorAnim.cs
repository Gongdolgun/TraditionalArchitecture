using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH_DoorAnim : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void open()
    {
        animator.Play("Moon");
    }

    public void close()
    {
        animator.Play("Moon 0");
    }
}
