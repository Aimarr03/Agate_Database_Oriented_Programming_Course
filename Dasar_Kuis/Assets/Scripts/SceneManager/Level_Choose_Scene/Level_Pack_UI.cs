using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Level_Pack_UI : MonoBehaviour
{
    public static event System.Action<LevelPack> OnClickTerbuka;
    public static event System.Action<Level_Pack_UI> OnClickTerkunci;
    public static event System.Action OnClickBeli;
    [SerializeField] private LevelPack _levelPack;
    [SerializeField] private TextMeshProUGUI _ButtonText;
    [SerializeField] private TextMeshProUGUI _HargaLevelPack;
    [SerializeField] private Transform PanelTerkunci;
    [SerializeField] private Button PurchaseButton;
    [SerializeField] private Choice_Animator choiceAnimator;
    public void Start()
    {
        _HargaLevelPack.text = _levelPack.harga.ToString();
    }
    public void _SetLevelPack(LevelPack currentLevelPack)
    {
        _levelPack = currentLevelPack;
        _ButtonText.text = _levelPack.ToString();
        DisplayTerkunci(_levelPack.terkunci);
    }
    public int GetPrice()
    {
        return _levelPack.harga;
    }
    public LevelPack GetLevelPack()
    {
        return _levelPack;
    }
    public void LevelPackUI_OnClick()
    {
        if (!_levelPack.terkunci)
        {
            OnClickTerbuka?.Invoke(_levelPack);
            choiceAnimator.SetBoolLevelChoice(true);
        }
        else
        {
            PurchaseButton.onClick.RemoveAllListeners();
            PurchaseButton.onClick.AddListener(Membeli);
            OnClickTerkunci?.Invoke(this);
            choiceAnimator.SetBoolPanelBuy(true);
        }
    }
    public void Membeli()
    {
        OnClickBeli?.Invoke();
    }
    public void DisplayTerkunci(bool status)
    {
        PanelTerkunci.gameObject.SetActive(status);
    }
    public void SetTerkunci(bool status)
    {
        _levelPack.terkunci = status;
        DisplayTerkunci(status);
    }
}
