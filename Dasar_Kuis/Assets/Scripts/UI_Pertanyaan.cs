using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Pertanyaan : MonoBehaviour
{
    private string jawaban;
    [SerializeField] private TextMeshProUGUI kontenJawaban;
    private bool nilaiBenar;
    public void TekanTombol()
    {
        string nilaiJawaban = nilaiBenar ? "benar" : "salah";
        string pesan = "Jawaban Anda adalah " + jawaban + " \njawaban ini " + nilaiJawaban; 
        Pesan_UI.instance.TampilPesan(pesan);
        if(nilaiBenar)
        {
            Pesan_UI.instance.Benar();
            Debug.Log("Jawaban Benar!");
        }
        else
        {
            Pesan_UI.instance.Salah();
            Debug.Log("Jawaban Salah!");
        }
    }
    public void SetNilai(string jawaban, bool nilaiBenar)
    {
        this.jawaban = jawaban;
        this.kontenJawaban.text = jawaban;
        this.nilaiBenar = nilaiBenar;
    }
}
