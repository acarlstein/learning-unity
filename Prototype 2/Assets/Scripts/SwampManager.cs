using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    public int animalIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(
                animalPrefabs[animalIndex], 
                new Vector3(0, 0, 20), 
                animalPrefabs[animalIndex].transform.rotation
            );
        }        
    }
}
