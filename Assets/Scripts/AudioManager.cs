using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip HitSound = null;
    [SerializeField] private AudioClip HealSound = null;
    [SerializeField] private AudioClip ShootSound = null;
    [SerializeField] private AudioClip WallHitSound = null;
    [SerializeField] private AudioClip ShieldSound = null;

    private AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();

        Player.PlayerHit += PlayHitSound;
        Medkit.OnHealed += PlayHealSound;
        PlayerMovement.OnShoot += PlayShootSound;
        PlayerMovement.OnWallHit += PlayWallHitSound;
        Shield.OnShield += PlayShieldSound;
    }

    private void PlayHitSound(int value)
    {
        AS.PlayOneShot(HitSound);
    }

    private void PlayHealSound(int value)
    {
        AS.PlayOneShot(HealSound);
    }

    private void PlayShootSound()
    {
        AS.PlayOneShot(ShootSound);
    }
    private void PlayWallHitSound()
    {
        AS.PlayOneShot(WallHitSound);
    }
    private void PlayShieldSound(int value)
    {
        AS.PlayOneShot(ShieldSound);
    }
}
