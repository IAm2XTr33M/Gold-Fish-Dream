using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public GameObject water;
    void Start()
    {
        Instantiate(water);
    }
}
