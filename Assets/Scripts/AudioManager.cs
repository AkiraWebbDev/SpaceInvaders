using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip explosionSound;
    public AudioClip playerRecharge;
    public AudioClip playerLevelUp;

    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            print("Audio source not found!");
        }
    }

    public void PlayExplosion()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(explosionSound);
    }

    public void PlayPlayerRecharge()
    {
        audioSource.pitch = 3;
        audioSource.PlayOneShot(playerRecharge);
    }

    public void PlayLevelUp()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(playerLevelUp);
    }
}
