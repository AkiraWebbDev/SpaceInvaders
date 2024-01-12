using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;
    private ParticleSystem particleSys;
    public float fillSpeed = 0.6f;
    private float targetProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("ProgressBarParticles").GetComponent<ParticleSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying)
            {
                particleSys.Play();
            }
        }
        else
        {
            particleSys.Stop();
        }
    }

    public void SetProgress(float inProgress)
    {
        print("Target Progress: " + targetProgress);
        if (inProgress == 0)
        {
            slider.value = 0;
            targetProgress = 0;
        }
        else
        {
            IncrementProgress(inProgress);
        }
    }
    
    private void IncrementProgress(float newProgress)
    {
        targetProgress = newProgress;
        if(targetProgress > 1)
        {
            targetProgress = 1;
        }
    }
}
