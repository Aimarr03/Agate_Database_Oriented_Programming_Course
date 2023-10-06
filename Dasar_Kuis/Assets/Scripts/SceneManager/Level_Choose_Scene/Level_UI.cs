using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_UI : MonoBehaviour
{
    public static event System.Action<InitialGameplayData> OnClick;

    [SerializeField] private QuestionData _questionData;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private int _indexLevel;
    public void SetQuestionData(QuestionData questionData, int indexLevel)
    {
        _questionData = questionData;
        _buttonText.text = questionData.namaSoal;
        _indexLevel = indexLevel;
    }
    public void Level_OnClicked()
    {
        _levelManager._GameplayData.IndexLevel = _indexLevel;
        OnClick?.Invoke(_levelManager._GameplayData);
        Audio_Manager.instance.TriggerSFX(0);
    }
}
