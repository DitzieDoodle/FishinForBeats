using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPositions;
    public Transform parent;

    public void Spawn()
    {
        GameObject.Instantiate(prefab, spawnPositions[UnityEngine.Random.Range(0,spawnPositions.Length)].position, Quaternion.identity, parent);
    }
   
}
