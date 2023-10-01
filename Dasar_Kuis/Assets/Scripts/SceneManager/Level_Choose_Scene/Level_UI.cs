using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_UI : MonoBehaviour
{
    [SerializeField] private QuestionData _questionData;
    [SerializeField] private TextMeshProUGUI _buttonText;
    public void SetQuestionData(QuestionData questionData)
    {
        _questionData = questionData;
        _buttonText.text = questionData.namaSoal;
    }
}
