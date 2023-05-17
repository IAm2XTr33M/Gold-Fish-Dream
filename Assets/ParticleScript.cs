using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ParticleScript : MonoBehaviour
{
    ParticleSystem Waterwalk;
    bool paused;

    private void Start()
    {
        Waterwalk = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0)
        {
            Waterwalk.Play();
            paused = false;
        }
        else if(!paused)
        {
            paused = true;

            StartCoroutine(StopParticles());

            IEnumerator StopParticles()
            {
                Waterwalk.Stop();
                yield return new WaitForSeconds(0.8f);
                Waterwalk.Pause();
                Waterwalk.Clear();
            }
        }

    }
}
