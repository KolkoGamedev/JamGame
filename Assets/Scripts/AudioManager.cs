using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{   
    [SerializeField] private AudioClip HitSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float HitVolume;

    [SerializeField] private AudioClip HealSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float HealVolume;

    [SerializeField] private AudioClip ShootSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float ShootVolume;

    [SerializeField] private AudioClip WallHitSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float WallHitVolume;

    [SerializeField] private AudioClip ShieldSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float ShieldVolume;

    [SerializeField] private AudioClip TeleportSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float TeleportVolume;

    [SerializeField] private AudioClip OnButtonClickSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float OnButtonClickVolume;


    [SerializeField] private AudioSource AS = null;


    

    private void Awake()
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
        Debug.Log("DZIALA");
        AS.mute = true;
        
        
    }

    private void UnMuteEffects()
    {
        AS.mute = false;
    }

}
