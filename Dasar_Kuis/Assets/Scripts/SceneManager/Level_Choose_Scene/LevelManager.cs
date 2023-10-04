using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public InitialGameplayData _GameplayData;

    [SerializeField] private TextMeshProUGUI Headline;
    [SerializeField] private Transform _LevelContainer;
    [SerializeField] private Transform _LevelUIFormat;
    [SerializeField] private Transform _LevelPackContainer;
    [SerializeField] private Button LevelBackButton;

    private string _HeadLineText_Level;
    private string _HeadLineText_LevelPack;


    public void Awake()
    {
        Level_Pack_UI.OnClickTerbuka += Level_Pack_UI_OnClick;
        _HeadLineText_Level = "Pilih Level yang tersedia!";
        _HeadLineText_LevelPack = "Pilih level pack yang tersedia!";
        Headline.text = _HeadLineText_LevelPack;
        gameObject.SetActive(false);
        _LevelUIFormat.gameObject.SetActive(false);
        LevelBackButton.gameObject.SetActive(false);
    }
    public void OnDestroy()
    {
        Level_Pack_UI.OnClickTerbuka -= Level_Pack_UI_OnClick;
    }
    private void Level_Pack_UI_OnClick(LevelPack currentLevelPack)
    {
        _GameplayData.levelPack = currentLevelPack;
        _LevelPackContainer.gameObject.SetActive(false);
        gameObject.SetActive(true);
        LevelBackButton.gameObject.SetActive(true);
        Headline.text = _HeadLineText_Level;

        foreach (Transform child in _LevelContainer)
        {
            if (child == _LevelUIFormat) continue;
            Destroy(child.gameObject);
        }
        QuestionData[] _CurrentQuestionsData = currentLevelPack.levelPack;
        ProgressLevel levelProgress = BinaryProgressLevelManager.instance.GetPlayerProgressLevel();
        ProgressLevel.DataProgress _dataProgress= levelProgress._PlayerProgressLevel[_GameplayData.levelPack.indexLevelPack];
        bool[] _dataPertanyaan = _dataProgress._LevelPackProgress;
        int indexLevel = 0;
        foreach (QuestionData currentQuestion in _CurrentQuestionsData)
        {
            if (_dataPertanyaan[indexLevel])
            {
                currentQuestion._DijawabBenar = true;
            }
            Transform _CurrentLevelUI = Instantiate(_LevelUIFormat, _LevelContainer);
            _CurrentLevelUI.gameObject.SetActive(true);
            _CurrentLevelUI.gameObject.TryGetComponent<Level_UI>(out Level_UI currentLevelUI);
            currentLevelUI.SetQuestionData(currentQuestion,indexLevel);
            indexLevel++;
        }
    }

    public void BackButton()
    {
        gameObject.SetActive(false);
        LevelBackButton.gameObject.SetActive(false);
        _LevelPackContainer.gameObject.SetActive(true);
        Headline.text = _HeadLineText_LevelPack;
    }

    //Alternative SetLevel without using events
    public void SetLevel(Level_Pack_UI levelPackUI)
    {
        LevelPack levelPack = levelPackUI.GetLevelPack();
        _LevelPackContainer.gameObject.SetActive(false);
        gameObject.SetActive(true);
        LevelBackButton.gameObject.SetActive(true);
        Headline.text = _HeadLineText_Level;

        foreach(Transform child in _LevelContainer)
        {
            if (child == _LevelUIFormat) continue;
            Destroy(child.gameObject);
        }
        int indexLevel = 0;
        QuestionData[] _CurrentQuestionsData = levelPack.levelPack;
        foreach(QuestionData currentQuestion in _CurrentQuestionsData)
        {
            Transform _CurrentLevelUI = Instantiate(_LevelUIFormat, _LevelContainer);
            _CurrentLevelUI.gameObject.SetActive(true);
            _CurrentLevelUI.gameObject.TryGetComponent<Level_UI>(out Level_UI currentLevelUI);
            currentLevelUI.SetQuestionData(currentQuestion, indexLevel);
            indexLevel++;

        }
    }
}
