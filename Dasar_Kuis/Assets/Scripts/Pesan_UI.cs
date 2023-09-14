using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pesan_UI : MonoBehaviour
{
    [SerializeField] private Transform pesan_Panel;
    [SerializeField] private TextMeshProUGUI text_Pesan;
    public Button prevButton;
    public Button nextButton;
    private string Pesan_Text;
    private Color salah = new Color(255,0,0);
    private Color benar = new Color(115,255,115);
    public static Pesan_UI instance;
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
    public void TampilPesan(string pesan)
    {
        gameObject.SetActive(true);
        text_Pesan.text = pesan;
    }
    public void TutupPesan()
    {
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
