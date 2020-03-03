using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Maps;
using Menus;
using Player;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class AudioManager : MonoBehaviour
{   
    [SerializeField] private AudioClip hitSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float hitVolume = 0;

    [SerializeField] private AudioClip healSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float healVolume = 0;

    [SerializeField] private AudioClip shootSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float shootVolume = 0;

    [SerializeField] private AudioClip wallHitSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float wallHitVolume = 0;

    [SerializeField] private AudioClip shieldSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float shieldVolume = 0;

    [SerializeField] private AudioClip teleportSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float teleportVolume = 0;

    [SerializeField] private AudioClip buttonClickSound = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float buttonClickVolume = 0;

    [SerializeField] private AudioSource audioSource = null;

    [SerializeField] private bool isMuted = false;
    

    private void Awake()
    {
        if (audioSource == null)
            audioSource = FindObjectOfType<AudioSource>();

        SetupSounds();
        SceneManager.sceneLoaded += SceneLoaded;

        

        DontDestroyOnLoad(gameObject);
    }
    private void SceneLoaded(Scene x, LoadSceneMode l)
    {
        if (audioSource == null)
            audioSource = FindObjectOfType<AudioSource>();

        SetupSounds();

    }

    private void SetupSounds()
    {
        PlayerHealth.OnHit += PlayHitSound;
        PlayerHealth.OnHeal += PlayHealSound;
        PlayerMovement.OnShoot += PlayShootSound;
        PlayerMovement.OnWallHit += PlayWallHitSound;
        Player.PlayerUtilities.OnShield += PlayShieldSound;
        Dissolve.OnDissolve += PlayTeleportSound;
        ClickableButton.OnButtonClick += PlayOnButtonClickSound;
        SoundButtonScripts.OnMute += MuteEffects;
        SoundButtonScripts.OnUnMute += UnMuteEffects;
    }
    private void PlayHitSound(int value)
    {
        audioSource.PlayOneShot(hitSound,hitVolume);
    }

    private void PlayHealSound(int value)
    {
        audioSource.PlayOneShot(healSound,healVolume);
    }

    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound,shootVolume);
    }
    private void PlayWallHitSound()
    {
        audioSource.PlayOneShot(wallHitSound,wallHitVolume);
    }
    private void PlayShieldSound()
    {
        audioSource.PlayOneShot(shieldSound,shieldVolume);
    }

    private void PlayTeleportSound()
    {
        audioSource.PlayOneShot(teleportSound,teleportVolume);
    }

    private void PlayOnButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound,buttonClickVolume);
    }

    private void MuteEffects()
    {
        audioSource.mute = true;
        isMuted = true;
        
    }

    private void UnMuteEffects()
    {
        audioSource.mute = false;
        isMuted = false;
    }

}
}

