using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Managers")]
    public AudioSource musicManager;
    public AudioSource sfxManager;

    [Header("Music")]
    public AudioClip village;
    public AudioClip dungeon;
    public AudioClip fight;

    [Header("Sounds")]
    public AudioClip damage;
    public AudioClip sword;
    public AudioClip projectile;
    public AudioClip explosion;
    public AudioClip chest_jingle;
    public AudioClip death;
    public AudioClip interact;
    public AudioClip switchSound;

    public void PlayMusic(string SceneName)
    {
        switch (SceneName)
        {
            case "Overworld": //Village
                PlayVillageMusic();
                break;
            case "Naheulbeuk": // Dungeon
                PlayDungeonMusic();
                break;
            default:
                PlayVillageMusic();
                break;
        }
    }

    public void PlayVillageMusic()
    {
        musicManager.Stop();
        musicManager.PlayOneShot(village, 0.65f);
    }

    public void PlayDungeonMusic()
    {
        musicManager.Stop();
        musicManager.PlayOneShot(dungeon, 0.65f);
    }

    public void PlayCombatMusic()
    {
        musicManager.Stop();
        musicManager.PlayOneShot(fight, 0.65f);
    }

    public void PlaySwordSound()
    {
        sfxManager.PlayOneShot(sword, 0.60f);
    }

    public void PlayProjectileSound()
    {
        sfxManager.PlayOneShot(projectile, 0.85f);
    }

    public void PlayChestJingle()
    {
        sfxManager.PlayOneShot(chest_jingle, 0.60f);
    }

    public void PlayKillSound()
    {
        sfxManager.PlayOneShot(death, 0.60f);
    }

    public void PlayDamageSound()
    {
        sfxManager.PlayOneShot(damage, 0.60f);
    }

    public void PlaySwitchSound()
    {
        sfxManager.PlayOneShot(switchSound, 0.60f);
    }
    
    public void PlayInteractSound()
    {
        sfxManager.PlayOneShot(interact, 0.60f);
    }

    public void PlayExplosionSound()
    {
        sfxManager.PlayOneShot(explosion, 0.75f);
    }
}
