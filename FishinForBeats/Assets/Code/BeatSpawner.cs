using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject[] prefabEasy;
    public GameObject[] prefabMedium;
    public GameObject[] prefabHard;
    public Transform[] spawnPositions;
    public Transform parent;
    public BeatsManager beatsManager;
    public ComboManager comboManager;

    
    public void Spawn()
    {
        GameObject[] spawnArray;
        if(comboManager.comboLevel>=30)
        {
            spawnArray = prefabHard;
        }

        else if(comboManager.comboLevel>=15)
        {
            spawnArray = prefabMedium;
        }

        else
        { 
            spawnArray = prefabEasy;
        }
      

        GameObject.Instantiate(spawnArray[Random.Range(0, spawnArray.Length)], spawnPositions[UnityEngine.Random.Range(0,spawnPositions.Length)].position, Quaternion.identity, parent);
    }
   
}
