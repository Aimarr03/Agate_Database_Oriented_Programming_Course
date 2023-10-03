using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private BinaryProgressLevelManager progressLevelManager;
    [SerializeField] private TextMeshProUGUI coinDisplay;
    // Start is called before the first frame update
    public void Start()
    {
        ProgressLevel progressLevel = progressLevelManager.GetPlayerProgressLevel();
        coinDisplay.text = progressLevel.koin.ToString();
    }
}
