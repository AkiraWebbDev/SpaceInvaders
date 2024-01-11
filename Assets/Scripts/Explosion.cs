using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        if (audioManager != null)
        {
            audioManager.PlayExplosion();
        }
    }

    public void FinishedExplosion()
    {
        Destroy(gameObject);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
