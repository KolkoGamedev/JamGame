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
    [SerializeField] private AudioClip TeleportSound = null;

    [SerializeField] private AudioSource AS;

    private void Awake()
    {
        PlayerHealth.OnHit += PlayHitSound;
        PlayerHealth.OnHeal += PlayHealSound;
        PlayerMovement.OnShoot += PlayShootSound;
        PlayerMovement.OnWallHit += PlayWallHitSound;
        PlayerUtilities.OnShield += PlayShieldSound;
        Dissolve.OnDissolve += PlayTeleportSound;
        
    }

    private void PlayHitSound(int value)
    {
        AS.PlayOneShot(HitSound,0.2f);
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
        AS.PlayOneShot(WallHitSound,0.1f);
    }
    private void PlayShieldSound()
    {
        AS.PlayOneShot(ShieldSound);
    }

    private void PlayTeleportSound()
    {

        AS.PlayOneShot(TeleportSound,0.4f);
    }
}
