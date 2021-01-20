using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAction : MonoBehaviour
{
    [SerializeField]protected Animator animator;
    [SerializeField]protected string animationName;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void OnMouseDown(){
        if(!animator.GetBool(animationName))
        {
            animator.SetBool(animationName,true);
        }else if(animator.GetBool(animationName))
        {
            animator.SetBool(animationName,false);
        }
    }
}
