using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveUpDown : MonoBehaviour
{
    float currentTime = 0;

    public float multiplier = 1;

    bool up = true;

    private void Update()
    {
        float add = Time.deltaTime * Random.Range(0.9f, 1.1f);
        currentTime += add;
        if (up)
        {
            transform.position += new Vector3(0, add * multiplier, 0);
        }
        else
        {
            transform.position -= new Vector3(0, add * multiplier, 0);
        }
        if (currentTime > 2)
        {
            currentTime = 0;
            up = !up;
        }
    }
}
