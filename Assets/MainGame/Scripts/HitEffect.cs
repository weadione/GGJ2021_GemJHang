using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Animator animator;

    public void RunEffect()
    {
        animator.SetTrigger("runEffect");
    }
}
