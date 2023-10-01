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
    public Button prevButton;
    public Button nextButton;
    private string Pesan_Text;
    private Color salah;
    private Color benar;
    public bool sudahJawab = false;
    private void Awake()
    {
        instance = this;
        sudahJawab = false;
        gameObject.SetActive(false);
        PilihanJawaban.gameObject.SetActive(true);
        benar = new(115, 255, 115);
        salah = new(255, 0, 0);
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
        gameObject.SetActive(false);
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
