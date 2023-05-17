using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public Vector3 spawnArea;
    public int boatSpawns;

    public List<GameObject> boats = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < boatSpawns; i++)
        {
            int num = Random.Range(0,boats.Count);
            GameObject obj = Instantiate(boats[num]);
            Vector3 randomPos = new Vector3(Random.Range((0 - spawnArea.x / 2), spawnArea.x / 2), obj.transform.position.y, Random.Range((0 - spawnArea.z / 2), spawnArea.z  / 2));
            obj.transform.position = randomPos;
            obj.transform.parent = transform;
            obj.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }
}
