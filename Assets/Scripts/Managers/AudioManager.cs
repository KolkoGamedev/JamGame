using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{   
    [SerializeField] private AudioClip HitSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float HitVolume = 0;

    [SerializeField] private AudioClip HealSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float HealVolume = 0;

    [SerializeField] private AudioClip ShootSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float ShootVolume = 0;

    [SerializeField] private AudioClip WallHitSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float WallHitVolume = 0;

    [SerializeField] private AudioClip ShieldSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float ShieldVolume = 0;

    [SerializeField] private AudioClip TeleportSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float TeleportVolume = 0;

    [SerializeField] private AudioClip OnButtonClickSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float OnButtonClickVolume = 0;

    [SerializeField] private AudioSource AS = null;

    [SerializeField] private bool isMuted = false;
    

    private void Awake()
    {
        if (AS == null)
            AS = FindObjectOfType<AudioSource>();

        SetupSounds();
        SceneManager.sceneLoaded += SceneLoaded;

        

        DontDestroyOnLoad(gameObject);
    }
    private void SceneLoaded(Scene x, LoadSceneMode l)
    {
        if (AS == null)
            AS = FindObjectOfType<AudioSource>();

        SetupSounds();

    }

    private void SetupSounds()
    {
        PlayerHealth.OnHit += PlayHitSound;
        PlayerHealth.OnHeal += PlayHealSound;
        PlayerMovement.OnShoot += PlayShootSound;
        PlayerMovement.OnWallHit += PlayWallHitSound;
        PlayerUtilities.OnShield += PlayShieldSound;
        Dissolve.OnDissolve += PlayTeleportSound;
        ClickableButton.OnButtonClick += PlayOnButtonClickSound;
        SoundButtonScripts.OnMute += MuteEffects;
        SoundButtonScripts.UnMute += UnMuteEffects;
    }
    private void PlayHitSound(int value)
    {
        AS.PlayOneShot(HitSound,HitVolume);
    }

    private void PlayHealSound(int value)
    {
        AS.PlayOneShot(HealSound,HealVolume);
    }

    private void PlayShootSound()
    {
        AS.PlayOneShot(ShootSound,ShootVolume);
    }
    private void PlayWallHitSound()
    {
        AS.PlayOneShot(WallHitSound,WallHitVolume);
    }
    private void PlayShieldSound()
    {
        AS.PlayOneShot(ShieldSound,ShieldVolume);
    }

    private void PlayTeleportSound()
    {
        AS.PlayOneShot(TeleportSound,TeleportVolume);
    }

    private void PlayOnButtonClickSound()
    {
        AS.PlayOneShot(OnButtonClickSound,OnButtonClickVolume);
    }

    private void MuteEffects()
    {
        AS.mute = true;
        isMuted = true;
        
    }

    private void UnMuteEffects()
    {
        AS.mute = false;
        isMuted = false;
    }

}
