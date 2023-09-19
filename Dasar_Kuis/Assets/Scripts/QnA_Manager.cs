using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QnA_Manager : MonoBehaviour
{
    //Referensi untuk Bagian Jawaban dan pilihannya
    [SerializeField] private Transform answerContainer;
    [SerializeField] private Transform answerTemplate;

    //Referensi untuk bagian pertanyaan yang meliputi gambar dan teks pertanyaan
    [SerializeField] private TextMeshProUGUI pertanyaan;
    [SerializeField] private Image gambarPertanyaan;
    [SerializeField] private TextMeshProUGUI levelText;
    //Untuk merekam sedang melakukan pertanyaan keberapa
    public int indexPertanyaan;

    //Untuk membuat struktur data untuk memuat format soal
    [SerializeField] private LevelPack dataSoal;
    [SerializeField] private ProgressLevel playerProgress;
    [SerializeField] private TimerScript timeScript;

    public void Awake()
    {
        CheckSoal();
        indexPertanyaan = 0;
        LoadSoal();
        playerProgress.SimpanProgress();
    }
    public void nextSoal()
    {
        if(indexPertanyaan < dataSoal.levelPack.Length)
        {
            indexPertanyaan++;
            Pesan_UI.instance.TutupPesan();
            LoadSoal();
            CheckSoal();
            timeScript.resetTime();
        }
    }
    public void prevSoal()
    {
        if (indexPertanyaan > 0)
        {
            indexPertanyaan--;
            Pesan_UI.instance.TutupPesan();
            CheckSoal();
            LoadSoal();
            timeScript.resetTime();
        }
    }
    public void LoadSoal()
    {
        QuestionData dataSoalKini = dataSoal.GetQuestion(indexPertanyaan);
        SetTextLevel();
        pertanyaan.text = dataSoalKini.pertanyaan;
        gambarPertanyaan.sprite = dataSoalKini.gambarSoal;
        int indexPilihan = 0;
        foreach (Transform child in answerContainer)
        {
            child.TryGetComponent<UI_Pertanyaan>(out UI_Pertanyaan pilihanKini);
            QuestionData.AnswerData dataJawabanKini = dataSoalKini.jawabanSoal[indexPilihan];
            pilihanKini.SetNilai(dataJawabanKini.jawaban,dataJawabanKini.nilaiBenar);
            indexPilihan++;
        }
    }
    public void SetTextLevel()
    {
        levelText.text = "Level " + (indexPertanyaan + 1);
    }
    public void CheckSoal()
    {
        if(indexPertanyaan > 0)
        {
            Pesan_UI.instance.prevButton.gameObject.SetActive(true);
        }
        else
        {
            Pesan_UI.instance.prevButton.gameObject.SetActive(false);
        }
        if(indexPertanyaan < dataSoal.levelPack.Length-1)
        {
            Pesan_UI.instance.nextButton.gameObject.SetActive(true);
        }
        else
        {
            Pesan_UI.instance.nextButton.gameObject.SetActive(false);
        }
    }
}
