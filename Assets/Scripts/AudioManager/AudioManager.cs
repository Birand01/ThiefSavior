using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSO[] sounds;

    private void OnEnable()
    {
        PistolInteraction.OnPlayerGunTakeSoundHandler += PlaySound;
        MachineGunInteraction.OnPlayerGunTakeSoundHandler += PlaySound;
        MoneyManager.OnMoneyDropSound += PlaySound;
        MoneyInteraction.OnPlayerCollectMoneySound += PlaySound;
        ATMInteraction.OnPlayerATMEnteranceSound += PlaySound;
        PlayerHealth.OnPlayerDeadSound += PlaySound;
        GunBase.OnPlayerShootSound += PlaySound;
    }
    private void Awake()
    {
        SoundConfiguration();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        PlaySound("BgMusic", true);
    }

    private void SoundConfiguration()
    {
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.loop = sound.loop;
        }
    }
    public void PlaySound(string soundName,bool state)
    {
        AudioSO audio = Array.Find(sounds, sound => sound.name == soundName);

        if (state)
        {
            if (audio == null)
                return;
            audio.audioSource.Play();
        }
        else
            audio.audioSource.Stop();

    }
    private void OnDisable()
    {
        PistolInteraction.OnPlayerGunTakeSoundHandler -= PlaySound;
        MachineGunInteraction.OnPlayerGunTakeSoundHandler -= PlaySound;
        MoneyInteraction.OnPlayerCollectMoneySound -= PlaySound;
        ATMInteraction.OnPlayerATMEnteranceSound -= PlaySound;
        PlayerHealth.OnPlayerDeadSound -= PlaySound;
        GunBase.OnPlayerShootSound -= PlaySound;
        MoneyManager.OnMoneyDropSound -= PlaySound;

    }
}
