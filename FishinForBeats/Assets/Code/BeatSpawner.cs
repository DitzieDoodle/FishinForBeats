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

    public GameObject juiceA;
    public GameObject juiceB;
    public GameObject juiceC;
    public void Spawn()
    {
        GameObject[] spawnArray;
        if (comboManager.comboLevel >= 30)
        {
            spawnArray = prefabHard;
            juiceA.SetActive(false);
            juiceB.SetActive(false);
            juiceC.SetActive(true);
        }


        else if (comboManager.comboLevel >= 15)
        {
            juiceA.SetActive(false);
            juiceB.SetActive(true);
            juiceC.SetActive(false);
            spawnArray = prefabMedium;
            
        }

        else
        {
            spawnArray = prefabEasy;
            juiceA.SetActive(true);
            juiceB.SetActive(false);
            juiceC.SetActive(false);
        }
      

        GameObject.Instantiate(spawnArray[Random.Range(0, spawnArray.Length)], spawnPositions[UnityEngine.Random.Range(0,spawnPositions.Length)].position, Quaternion.identity, parent);
    }
   
}
