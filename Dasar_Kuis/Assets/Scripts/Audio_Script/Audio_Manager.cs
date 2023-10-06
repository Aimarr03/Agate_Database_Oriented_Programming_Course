using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    public AudioClip[] sfxList;
    public AudioClip[] bgmList;
    public AudioSource BackGroundMusicManager;
    public AudioSource SFXManager;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        if(instance == null) { instance = this; }
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeMusic(int index)
    {
        if(BackGroundMusicManager.clip == bgmList[index])
        {
            return;
        }
        BackGroundMusicManager.Stop();
        BackGroundMusicManager.clip = bgmList[index];
        BackGroundMusicManager.Play();
    }
    public void TriggerSFX(int index)
    {
        SFXManager.PlayOneShot(sfxList[index]);
    }
}
