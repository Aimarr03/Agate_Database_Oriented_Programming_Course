using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Headline;
    [SerializeField] private Transform _LevelContainer;
    [SerializeField] private Transform _LevelUIFormat;
    [SerializeField] private Transform _LevelPackContainer;
    [SerializeField] private Button LevelBackButton;

    private string _HeadLineText_Level;
    private string _HeadLineText_LevelPack;
    public void Awake()
    {
        _HeadLineText_Level = "Pilih Level yang tersedia!";
        _HeadLineText_LevelPack = "Pilih level pack yang tersedia!";
        Headline.text = _HeadLineText_LevelPack;
        gameObject.SetActive(false);
        _LevelUIFormat.gameObject.SetActive(false);
        LevelBackButton.gameObject.SetActive(false);
    }
    public void BackButton()
    {
        gameObject.SetActive(false);
        LevelBackButton.gameObject.SetActive(false);
        _LevelPackContainer.gameObject.SetActive(true);
        Headline.text = _HeadLineText_LevelPack;
    }
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
        QuestionData[] _CurrentQuestionsData = levelPack.levelPack;
        foreach(QuestionData currentQuestion in _CurrentQuestionsData)
        {
            Transform _CurrentLevelUI = Instantiate(_LevelUIFormat, _LevelContainer);
            _CurrentLevelUI.gameObject.SetActive(true);
            _CurrentLevelUI.gameObject.TryGetComponent<Level_UI>(out Level_UI currentLevelUI);
            currentLevelUI.SetQuestionData(currentQuestion);

        }
    }
}
