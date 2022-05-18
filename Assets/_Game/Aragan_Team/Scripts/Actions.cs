using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour
{
    private Animator animator;
    


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Stay(){
        animator.SetFloat("Speed",0f);
    }

    public void Run(){
      animator.SetFloat("Speed",1f);
    }

    public void Jump(){
        animator.SetFloat("Speed", 0f);
        animator.SetTrigger("Jump");
    }
    


}
