using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void TriggerTransition()
    {
        animator.SetTrigger("Transition");
    }
}
