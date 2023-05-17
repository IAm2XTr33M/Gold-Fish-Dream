using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StartFade : MonoBehaviour
{
    public Volume volume;
    ColorAdjustments color;

    private void Start()
    {
        volume = GetComponent<Volume>();

        if (volume.profile.TryGet<ColorAdjustments>(out color))
        {
            color.postExposure.value = 8;
        }
    }

    private void Update()
    {
        if(color.postExposure.value > 0)
        {
            color.postExposure.value -= Time.deltaTime * 1.5f;
        }
    }
}
