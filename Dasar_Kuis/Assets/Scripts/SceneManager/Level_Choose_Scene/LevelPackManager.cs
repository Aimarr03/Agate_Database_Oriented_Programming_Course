using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPackManager : MonoBehaviour
{
    [SerializeField] private BinaryProgressLevelManager progressLevelManager;
    [SerializeField] private List<LevelPack> _ListLevelPack;
    [SerializeField] private Transform _LevelPackContainer;
    [SerializeField] private Transform _LevelPackButtonFormat;
    public ProgressLevel currentProgressLevel;

    //[SerializeField] private ProgressLevel progressLevel;
    private string _HeadLineText;
    public void Start()
    {
        currentProgressLevel = progressLevelManager.GetPlayerProgressLevel();
        //ProgressLevel currentProgressLevel = progressLevelManager.GetPlayerProgressLevel();
        //currentCoin.text = ""+progressLevel.dataProgress.koin;
        _LevelPackButtonFormat.gameObject.SetActive(false);
        foreach (Transform child in _LevelPackContainer)
        {
            if(child != _LevelPackButtonFormat)
            {
                Destroy(child);
            }
        }
        foreach(LevelPack levelPack in _ListLevelPack)
        {
            foreach(ProgressLevel.DataProgress _keyName in currentProgressLevel._PlayerProgressLevel)
            {
                Debug.Log(_keyName);
                Debug.Log(_keyName._NamaLevelPack == levelPack.ToString());
                if(_keyName._NamaLevelPack == levelPack.ToString())
                {
                    levelPack.terkunci = false;
                }
            }
            Transform currentLevelpPack = Instantiate(_LevelPackButtonFormat, _LevelPackContainer);
            Level_Pack_UI _levelPackUI = currentLevelpPack.gameObject.GetComponent<Level_Pack_UI>();
            _levelPackUI._SetLevelPack(levelPack);
            currentLevelpPack.gameObject.SetActive(true);
        }
    }
}
