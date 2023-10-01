using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Game/Create New Question", fileName ="New Question")]
public class QuestionData : ScriptableObject
{
    [System.Serializable]
    public struct AnswerData
    {
        public string jawaban;
        public bool nilaiBenar;
    }
    public string pertanyaan = string.Empty;
    public Sprite gambarSoal = null;
    public string namaSoal;
    [Header("Jawaban-Jawaban Soal")]
    public AnswerData[] jawabanSoal = new AnswerData[0];
}
