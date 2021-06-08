using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    public float rangeX = 20;
    public int poolSize = 10;

    private readonly float positionZ = 20;
    private readonly float startDelay = 2.0f;
    private readonly float spawnInterval = 1.5f;
    private List<ObjectPooler> objectPoolers;

    private void Start()
    {
        objectPoolers = new List<ObjectPooler>();
        for (int i = 0; i < animalPrefabs.Length; ++i)
        {
            GameObject gameObject = new GameObject();
            ObjectPooler objectPooler = gameObject.AddComponent<ObjectPooler>();
            objectPooler.pooledObject = animalPrefabs[i];
            objectPoolers.Add(objectPooler);
        }

        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animal = objectPoolers[animalIndex].GetPooledObject();
        animal.SetActive(true);

        float positionX = Random.Range(-rangeX, rangeX);
        Vector3 spawnPosition = new Vector3(positionX, 0, positionZ);

        Instantiate(animal, spawnPosition, animal.transform.rotation);
    }
}
