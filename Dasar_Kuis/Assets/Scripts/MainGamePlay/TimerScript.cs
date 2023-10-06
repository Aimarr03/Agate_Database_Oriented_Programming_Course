using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static event System.Action<string> TimeOver;
    [SerializeField] private float _timeRemaining;
    [SerializeField] private float _currentTime;
    [SerializeField] private Slider _timeUI;
    [SerializeField] private float _smoothnes;

    public void Awake()
    {
        _timeRemaining = 30f;
        _smoothnes = .5f;
    }
    private void Start()
    {
        _currentTime = _timeRemaining;
    }
    private void Update()
    {
        if (_currentTime > 0 && !Pesan_UI.instance.sudahJawab)
        {
            _currentTime -= Time.deltaTime;
            float normalizedTimer = calculateTimeNormalized();
            _timeUI.value = Mathf.Lerp(_timeUI.value, normalizedTimer, Time.deltaTime * _smoothnes);
        }
        else if (_currentTime <= 0)
        {
            string pesan = "Waktu Habis, anda tidak menjawab apa pun!";
            TimeOver?.Invoke(pesan);
            Audio_Manager.instance.TriggerSFX(4);
            //Pesan_UI.instance.TampilPesan(pesan);
            //Pesan_UI.instance.Salah();
        }
    }
    private float calculateTimeNormalized()
    {
        return _currentTime / _timeRemaining;
    }
    public void resetTime()
    {
        _currentTime = _timeRemaining;
        _timeUI.value = calculateTimeNormalized();
    }
}
