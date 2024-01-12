using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;
    private ParticleSystem particleSys;
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;

    private void Awake()
    {

        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("ProgressBarParticles").GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(0.80f);
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
        else if (slider.value >= 1f)
        {
            slider.value = 0;
        }
        else
        {
            particleSys.Stop();
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
