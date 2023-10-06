using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Animator_Script : MonoBehaviour
{
    public string _OpenPanel;
    [SerializeField] private Animator _animator;

    public void SetBoolOpenPanel(bool input)
    {
        _animator.SetBool(_OpenPanel, input);
    }
    public void SetTrigger(string input)
    {
        _animator.SetTrigger(input);
    }
}
