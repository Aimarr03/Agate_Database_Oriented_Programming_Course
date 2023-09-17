using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 30f;
    [SerializeField] private float currentTime;
    [SerializeField] private Slider timeUI;
    [SerializeField] private float smoothnes = .5f;
    private void Start()
    {
        currentTime = timeRemaining;
    }
    private void Update()
    {
        if(currentTime> 0)
        {
            currentTime -= Time.deltaTime;
            float normalizedTimer = calculateTimeNormalized();
            timeUI.value = Mathf.Lerp(timeUI.value, normalizedTimer, Time.deltaTime * smoothnes);
        }
        else
        {
            string pesan = "Waktu Habis, anda tidak menjawab apa pun!";
            Pesan_UI.instance.TampilPesan(pesan);
            Pesan_UI.instance.Salah();
        }
    }
    private float calculateTimeNormalized()
    {
        return currentTime/ timeRemaining;
    }
    public void resetTime()
    {
        currentTime = timeRemaining;
    }
}
