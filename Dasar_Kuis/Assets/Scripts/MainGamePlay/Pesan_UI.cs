using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pesan_UI : MonoBehaviour
{
    //Singleton Script Pesan_UI
    public static Pesan_UI instance;


    [SerializeField] private Transform pesan_Panel;
    [SerializeField] private TextMeshProUGUI text_Pesan;
    [SerializeField] private Transform PilihanJawaban;

    [SerializeField] private Transform TombolSalah;
    [SerializeField] private Transform TombolBenar;

    [SerializeField] private BinaryProgressLevelManager progressLevelManager;
    [SerializeField] private ProgressLevel PlayerProgressLevel;
    [SerializeField] private QnA_Manager QnA_manager;

    public Button TombolMainMenu;
    public Button prevButton;
    public Button nextButton;

    private string Pesan_Text;
    private Color salah;
    private Color benar;
    public bool sudahJawab = false;
    private void Awake()
    {
        instance = this;

        UI_Pertanyaan.AnswerChosen += UI_Pertanyaan_AnswerChosen;
        TimerScript.TimeOver += TimerScript_TimeOver;

        sudahJawab = false;
        gameObject.SetActive(true);
        PilihanJawaban.gameObject.SetActive(true);
        benar = new(115, 255, 115);
        salah = new(255, 0, 0);
        PlayerProgressLevel = progressLevelManager.GetPlayerProgressLevel();
    }
    private void UI_Pertanyaan_AnswerChosen(UI_Pertanyaan.DataDikirim _DataTerkirim)
    {
        TampilPesan(_DataTerkirim.pesan);
        CheckKebenaran(_DataTerkirim.jawabanBenar);
        if (!_DataTerkirim._QuestionDataReference._DijawabBenar)
        {
            PlayerProgressLevel.koin += 10;
            int indexLevelPack = QnA_manager.indexLevelPack;
            int indexPertanyaan = QnA_manager.indexPertanyaan;
            Debug.Log(indexPertanyaan);
            Debug.Log(indexLevelPack);
            Debug.Log(PlayerProgressLevel);
            Debug.Log(PlayerProgressLevel._PlayerProgressLevel[0]);
            Debug.Log(PlayerProgressLevel._PlayerProgressLevel[0]._LevelPackProgress[0]);
            PlayerProgressLevel._PlayerProgressLevel[indexLevelPack]._LevelPackProgress[indexPertanyaan] = true;
            progressLevelManager.Save(PlayerProgressLevel);
            _DataTerkirim._QuestionDataReference._DijawabBenar = true;
        }
    }

    private void TimerScript_TimeOver(string pesan)
    {
        TampilPesan(pesan);
        TombolSalah.gameObject.SetActive(true);
        Salah();
    }

    private void OnDestroy()
    {
        UI_Pertanyaan.AnswerChosen -= UI_Pertanyaan_AnswerChosen;
        TimerScript.TimeOver -= TimerScript_TimeOver;
    }
    public void TampilPesan(string pesan)
    {
        
        sudahJawab = true;
        gameObject.SetActive(true);
        PilihanJawaban.gameObject.SetActive(false);
        text_Pesan.text = pesan;
    }
    public void TutupPesan()
    {
        sudahJawab = false;
        PilihanJawaban.gameObject.SetActive(true);
    }
    public void CheckKebenaran(bool kebenaranNilai)
    {
        if (kebenaranNilai)
        {
            Benar();
            TombolBenar.gameObject.SetActive(true);
            TombolSalah.gameObject.SetActive(false);
        }
        else
        {
            Salah();
            TombolBenar.gameObject.SetActive(false);
            TombolSalah.gameObject.SetActive(true);
        }
    }
    public void Salah()
    {
        text_Pesan.color = salah;
    }
    public void Benar()
    {
        text_Pesan.color = benar;
    }
}
