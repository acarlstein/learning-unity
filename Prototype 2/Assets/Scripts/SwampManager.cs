using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    public float rangeX = 20;
    private readonly float positionZ = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            float positionX = Random.Range(-rangeX, rangeX);
            Vector3 spawnPosition = new Vector3(positionX, 0, positionZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(
                animalPrefabs[animalIndex],
                spawnPosition, 
                animalPrefabs[animalIndex].transform.rotation
            );
        }        
    }
}
