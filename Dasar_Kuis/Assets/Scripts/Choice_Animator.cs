using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Animator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private CoinDisplay coinDisplay;
    public string _levelChoiceParameter;
    public string _BuyingParameter;

    public void Awake()
    {
        Level_Pack_UI.OnClickTerkunci += Level_Pack_UI_OnClickTerkunci;
    }
    public void OnDestroy()
    {
        Level_Pack_UI.OnClickTerkunci -= Level_Pack_UI_OnClickTerkunci;
    }
    private void Level_Pack_UI_OnClickTerkunci(Level_Pack_UI obj)
    {
        SetBoolPanelBuy(true);
    }
    public void TriggerAnimator(string animatorTrigger)
    {
        animator.SetTrigger(animatorTrigger);
    }
    public void SetBoolPanelBuy(bool input)
    {
        animator.SetBool(_BuyingParameter, input);
    }
    public void SetBoolLevelChoice(bool input)
    {
        animator.SetBool(_levelChoiceParameter, input);
    }
}
