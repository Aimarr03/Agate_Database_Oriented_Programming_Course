using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Scene_Manager : MonoBehaviour
{
    [SerializeField] Level_Pack_UI test;
    [SerializeField] Transform TransactionPanel;
    private Transform suksesPanel;
    private Transform gagalPanel;
    [SerializeField] CoinDisplay coinDisplay;
    private string _gagalTransaksi;
    private string _suksesTransaksi;
    private int hargaKini;
    void Awake()
    {
        _suksesTransaksi = "Sukses";
        _gagalTransaksi = "Gagal";

        suksesPanel = TransactionPanel.Find(_suksesTransaksi);
        gagalPanel = TransactionPanel.Find(_gagalTransaksi);

        TransactionPanel.gameObject.SetActive(false);
        suksesPanel.gameObject.SetActive(false);
        gagalPanel.gameObject.SetActive(false);

        Level_Pack_UI.OnClickTerkunci += Level_Pack_UI_OnClickTerkunci;
        Level_Pack_UI.OnClickBeli += Level_Pack_UI_OnClickBeli;
    }

    private void Level_Pack_UI_OnClickTerkunci(Level_Pack_UI obj)
    {
        test = obj;
        int price = test.GetPrice();
        TransactionPanel.gameObject.SetActive(true);
        if (coinDisplay.CheckMoney(price))
        {
            suksesPanel.gameObject.SetActive(true);
            gagalPanel.gameObject.SetActive(false);
            hargaKini = price;
        }
        else
        {
            suksesPanel.gameObject.SetActive(false);
            gagalPanel.gameObject.SetActive(true);
        }
    }

    private void Level_Pack_UI_OnClickBeli()
    {
        test.SetTerkunci(false);
        coinDisplay.UseMoney(hargaKini);
        coinDisplay.UpdateUI();
        TransactionPanel.gameObject.SetActive(false);
        suksesPanel.gameObject.SetActive(false);
        gagalPanel.gameObject.SetActive(false);
        Transaksi();
    }
    private void Transaksi()
    {
        test.SetTerkunci(false);
        coinDisplay.UseMoney(test.GetPrice());
        coinDisplay.UpdateUI();
    }

    private void OnDestroy()
    {
        Level_Pack_UI.OnClickTerkunci -= Level_Pack_UI_OnClickTerkunci;
    }
    public void Kembali()
    {
        TransactionPanel.gameObject.SetActive(false);
        suksesPanel.gameObject.SetActive(false);
        gagalPanel.gameObject.SetActive(false);
    }
}
