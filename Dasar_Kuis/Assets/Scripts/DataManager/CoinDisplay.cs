using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private BinaryProgressLevelManager progressLevelManager;
    [SerializeField] private TextMeshProUGUI _CoinTextDisplay;
    private ProgressLevel progressLevel;
    // Start is called before the first frame update
    public void Start()
    {
        progressLevel = progressLevelManager.GetPlayerProgressLevel();
        UpdateUI();
    }
    public bool CheckMoney(int money)
    {
        return progressLevel.koin >= money ? true : false;
    }
    public void UseMoney(int money)
    {
        if(CheckMoney(money))
        {
            progressLevel.koin -= money;
        }
    }
    public void UpdateUI()
    {
        _CoinTextDisplay.text = progressLevel.koin.ToString();
    }
}
