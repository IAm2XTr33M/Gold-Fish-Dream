using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StartFade : MonoBehaviour
{
    Volume volume;
    ColorAdjustments color;
    public float start;
    public float target;
    bool up = false;
    bool switchScene = false;

    private void Start()
    {
        volume = GetComponent<Volume>();

        if (volume.profile.TryGet<ColorAdjustments>(out color))
        {
            color.postExposure.value = start;
        }

        if(start < target)
        {
            up = true;
        }
    }

    private void Update()
    {
        if (up && !switchScene)
        {
            if (color.postExposure.value < target)
            {
                color.postExposure.value += Time.deltaTime * 1.5f;
            }
        }
        else if (!up && !switchScene)
        {
            if (color.postExposure.value > target)
            {
                color.postExposure.value -= Time.deltaTime * 1.5f;
            }

        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switchScene = true;
            if (SceneManager.GetActiveScene().name == "Day")
            {
                StartCoroutine(endFade());

                IEnumerator endFade()
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    color.postExposure.value -= Time.deltaTime * 5.5f;
                    if (color.postExposure.value > -8.75f)
                    {
                        StartCoroutine(endFade());
                    }
                    else
                    {
                        SceneManager.LoadScene("Night");
                    }
                }
            }
            else
            {
                StartCoroutine(endFade());

                IEnumerator endFade()
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    color.postExposure.value += Time.deltaTime * 5.5f;
                    if (color.postExposure.value < 8.75f)
                    {
                        StartCoroutine(endFade());
                    }
                    else
                    {
                        SceneManager.LoadScene("Day");
                    }
                }
            }
        }
    }
}
