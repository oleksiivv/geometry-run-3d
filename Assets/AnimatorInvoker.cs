using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorInvoker : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator=GetComponent<Animator>();
        animator.enabled=false;
        
        Invoke(nameof(TurnOnAnimator), Random.Range(0.5f, 2f));
    }
    
    void TurnOnAnimator()
    {
        animator.enabled=true;
    }
}
